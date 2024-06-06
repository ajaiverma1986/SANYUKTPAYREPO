using Audit.WebApi;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SANYUKT.API.Common;
using SANYUKT.API.Security;
using SANYUKT.Datamodel.DTO.Request;
using SANYUKT.Datamodel.DTO.Response;
using SANYUKT.Datamodel.Shared;
using SANYUKT.Provider;

namespace SANYUKT.API.Controllers
{
    
    [EnableCors("AllowAll")]
    [ResponseCache(Duration = -1, Location = ResponseCacheLocation.None, NoStore = true)]
    [ServiceFilter(typeof(SANYUKTExceptionFilterService))]
    public class AAController : BaseApiController
    {
        private AuthenticationProvider _authenticationProvider;
        private AuthenticationHelper _callValidator = null;

        public AAController()
        {
            _authenticationProvider = new AuthenticationProvider();
            _callValidator = new AuthenticationHelper();
        }
        [HttpGet]
        public async Task<IActionResult> TestAPI(string Name)
        {
            UserLoginResponse response = new UserLoginResponse();
            response.DisplayName = Name;
            return Ok(response);
        }
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userLoginRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [AuditApi(EventTypeName = "POST AAController/Login", IncludeHeaders = true, IncludeResponseBody = true, IncludeRequestBody = false, IncludeModelState = false)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            UserLoginResponse response = new UserLoginResponse();

            ErrorResponse error = await _callValidator.AuthenticateAndAuthorize(this.CallerUser, false);
            if (error.HasError)
            {
                response.SetError(error);
                return Ok(response);
            }
            response = await _authenticationProvider.Login(userLoginRequest, this.CallerUser);

            return Ok(response);

        }
        

    }
}
