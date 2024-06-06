using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using SANYUKT.Logging;
using SANYUKT.Datamodel.Interfaces;
using SANYUKT.Datamodel.Shared;

namespace SANYUKT.MasterAPI.Common
{
    public class SANYUKTExceptionFilterService : ExceptionFilterAttribute
    {
        private readonly ILoggingService _loggingService;

        public SANYUKTExceptionFilterService(ILoggingService loggingService)
        {
            this._loggingService = loggingService;
        }

        public override void OnException(ExceptionContext context)
        {
            ISANYUKTServiceUser serviceUser = context.HttpContext.RequestServices.GetService(typeof(ISANYUKTServiceUser)) as ISANYUKTServiceUser;
            //Collect HTTP Request Details
            Log log = new Log();
            if (serviceUser != null)
            {
                log.ApiToken = serviceUser.ApiToken;
                log.UserToken = serviceUser.UserToken;
            }
            log.IpAddress = GetClientIpAddress(context.HttpContext);
            log.Url = GetRequestUrl(context.HttpContext.Request);
            log.ReferrerUrl = GetRequestReferrerUrl(context.HttpContext.Request);
            log.Headers = GetRequestHeaders(context.HttpContext.Request);
            _loggingService.LogError(context.Exception, log, this);
            BaseResponse response = new BaseResponse();
            response.SetError(ErrorCodes.SERVER_ERROR);
            context.Result = new ObjectResult(response);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }

        private string GetClientIpAddress(HttpContext httpContext)
        {
            string ipAddress = string.Empty;
            ipAddress = httpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = httpContext.Request.Headers["X-Forwarded-For"];
                if (!string.IsNullOrEmpty(ipAddress))
                {
                    ipAddress = ipAddress.Split(',')[0].Split(';')[0];
                    if (ipAddress.Contains(":"))
                    {
                        ipAddress = ipAddress.Substring(0, ipAddress.LastIndexOf(':'));
                    }
                }
            }
            return ipAddress;
        }

        private string GetRequestUrl(HttpRequest request)
        {
            return string.Concat(
                        request.Scheme,
                        "://",
                        request.Host.ToUriComponent(),
                        request.PathBase.ToUriComponent(),
                        request.Path.ToUriComponent(),
                        request.QueryString.ToUriComponent());
        }

        private string GetRequestReferrerUrl(HttpRequest request)
        {
            return request.Headers["Referer"];
        }

        private string GetRequestHeaders(HttpRequest request)
        {
            StringBuilder headers = new StringBuilder();
            foreach (var header in request.Headers)
            {
                headers.AppendLine(string.Format("{0}:{1}", header.Key, header.Value));
            }
            return headers.ToString();
        }
    }
}
