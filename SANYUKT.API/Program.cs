using Audit.Core;
using Audit.SqlServer.Providers;
using Audit.WebApi;
using Microsoft.AspNetCore.Http.Features;
using SANYUKT.API.Common;
using SANYUKT.Commonlib.Cache;
using SANYUKT.Configuration;
using SANYUKT.Datamodel.Common;
using SANYUKT.Datamodel.Entities.Application;
using SANYUKT.Datamodel.Entities.Authorization;
using SANYUKT.Datamodel.Interfaces;
using SANYUKT.Logging;
using SANYUKT.Provider;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SANYUKTExceptionFilterService>();
builder.Services.AddSingleton<ILoggingService, LoggingService>();
builder.Services.AddScoped<ISANYUKTServiceUser, SANYUKTServiceUser>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddMemoryCache();

//my data
Audit.Core.Configuration.DataProvider = new SqlDataProvider()
{
    ConnectionString = SANYUKTApplicationConfiguration.Instance.FIADB,
    Schema = "dbo",
    TableName = "Event",
    IdColumnName = "EventId",
    JsonColumnName = "Data",
    LastUpdatedDateColumnName = "LastUpdatedDate"
};

Audit.Core.Configuration.AddCustomAction(ActionType.OnEventSaving, scope =>
{
    if (scope != null && scope.Event != null)
    {
        if (scope.Event is AuditEventWebApi)
        {
            AuditApiAction mvc = (scope.Event as AuditEventWebApi).GetWebApiAuditAction();
            if (mvc != null && mvc.ActionParameters != null)
            {
                if (mvc.ActionParameters.ContainsKey("userLoginRequest"))
                {
                    if (mvc.ActionParameters["userLoginRequest"] is SANYUKT.Datamodel.DTO.Request.UserLoginRequest)
                        (mvc.ActionParameters["userLoginRequest"] as SANYUKT.Datamodel.DTO.Request.UserLoginRequest).Password = "***NOT-LOGGED***";
                }
            }
        }
    }
});
        

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    ISANYUKTServiceUser serviceUser = context.RequestServices.GetRequiredService<ISANYUKTServiceUser>();
    serviceUser.ApiToken = context.Request.Headers["apitoken"];
    serviceUser.UserToken = context.Request.Headers["usertoken"];

    if (string.IsNullOrEmpty(serviceUser.ApiToken))
    {
        serviceUser.ApiToken = context.Request.Query["apitoken"];
    }

    if (string.IsNullOrEmpty(serviceUser.UserToken))
    {
        serviceUser.UserToken = context.Request.Query["usertoken"];
    }

    Int64 UserMasterID = 0;

    ApplicationUserMappingResponse applicationUserDetails = null;
    if (!string.IsNullOrEmpty(serviceUser.UserToken))
        applicationUserDetails = await MemoryCachingService.Get<ApplicationUserMappingResponse>(string.Format(CacheKeys.APPLICATION_USER_DETAIL, serviceUser.UserToken));

    if (!string.IsNullOrEmpty(serviceUser.UserToken))
    {
        UserMasterID = await MemoryCachingService.Get<Int32>(string.Format(CacheKeys.USERMASTER_ID, serviceUser.UserToken));
    }

    if (applicationUserDetails == null || (!string.IsNullOrEmpty(serviceUser.UserToken) && UserMasterID == 0))
    {
        AuthenticationProvider _authenticationProvider = new AuthenticationProvider();
        applicationUserDetails = await _authenticationProvider.GetApplicationAndUserDetails(serviceUser);
        await MemoryCachingService.Put(string.Format(CacheKeys.APPLICATION_USER_DETAIL, serviceUser.UserToken), applicationUserDetails);

        if (applicationUserDetails != null && (applicationUserDetails.UserMasterID.HasValue))
        {
            await MemoryCachingService.Put(string.Format(CacheKeys.USERMASTER_ID, serviceUser.UserToken), applicationUserDetails.UserMasterID);
            UserMasterID = applicationUserDetails.UserMasterID.Value;
        }
    }

    if (applicationUserDetails != null)
    {
        serviceUser.ApplicationID = applicationUserDetails.ApplicationId;
        serviceUser.ApplicationName = applicationUserDetails.ApplicationName;
        serviceUser.AppType = applicationUserDetails.AppType;
        serviceUser.UserMasterID = UserMasterID;
        serviceUser.OrganizationID = applicationUserDetails.OrganizationID;
        serviceUser.WorkOrganizationID = applicationUserDetails.OrganizationID;

        serviceUser.RequestUrl = string.Concat(context.Request.Scheme,
            "://",
            context.Request.Host.ToUriComponent(),
            context.Request.PathBase.ToUriComponent(),
            context.Request.Path.ToUriComponent(),
            context.Request.QueryString.ToUriComponent());

        //Get http request referer url
        serviceUser.ReferrerUrl = context.Request.Headers["Referer"];

        //Get http request headers
        StringBuilder headers = new StringBuilder();
        foreach (var header in context.Request.Headers)
        {
            headers.AppendLine(string.Format("{0}:{1}", header.Key, header.Value));
        }
        serviceUser.Headers = headers.ToString();

        serviceUser.IPAddress = context.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();
        if (string.IsNullOrEmpty(serviceUser.IPAddress))
        {
            serviceUser.IPAddress = context.Request.Headers["X-Forwarded-For"];
            if (!string.IsNullOrEmpty(serviceUser.IPAddress))
            {
                serviceUser.IPAddress = serviceUser.IPAddress.Split(',')[0].Split(';')[0];
                if (serviceUser.IPAddress.Contains(":"))
                {
                    serviceUser.IPAddress = serviceUser.IPAddress.Substring(0, serviceUser.IPAddress.LastIndexOf(':'));
                }
            }
        }
        //Get client IP address
        serviceUser.ClientIPAddress = context.Request.Headers["ClientIPAddress"];
    }

    if (applicationUserDetails != null && applicationUserDetails.UserMasterID > 0)
    {
        if (serviceUser.UserMasterID == 0)
            serviceUser.UserMasterID = applicationUserDetails.UserMasterID;

        if (serviceUser.UserMasterID > 0 && !string.IsNullOrEmpty(serviceUser.UserToken))
        {

            List<UserApplicationAccessPermissions> userPermissions = await MemoryCachingService.Get<List<UserApplicationAccessPermissions>>(string.Format(CacheKeys.USER_ROLES_API, serviceUser.ApplicationID, serviceUser.UserToken));

            if (userPermissions == null || userPermissions.Count == 0)
            {
                AuthenticationProvider _authenticationProvider = new AuthenticationProvider();
                await MemoryCachingService.Put(string.Format(CacheKeys.USER_ROLES_API, serviceUser.ApplicationID, serviceUser.UserToken), _authenticationProvider.GetUserAccessPermissions(serviceUser).Result);
            }
               
        }
    }
    await next();
});

app.MapControllers();

app.Run();
