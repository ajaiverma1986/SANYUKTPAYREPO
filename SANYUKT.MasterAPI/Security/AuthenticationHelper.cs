using SANYUKT.Commonlib.Cache;
using SANYUKT.Datamodel.Common;
using SANYUKT.Datamodel.Interfaces;
using SANYUKT.Datamodel.Shared;
using SANYUKT.Provider;

namespace SANYUKT.API.Security
{
    public class AuthenticationHelper
    {
        private AuthenticationProvider _authenticationProvider;
        private AuthorizationHelper _customAuthorization;


        public AuthenticationHelper()
        {
            _authenticationProvider = new AuthenticationProvider();
            _customAuthorization = new AuthorizationHelper();
        }

        private async Task<ErrorResponse> Validate(ISANYUKTServiceUser serviceUser, bool validateBothToken = true, bool slidingExpiration = true)
        {
            ErrorResponse error = await IsValidToken(serviceUser, validateBothToken, slidingExpiration);
            if (error.HasError)
            {
                return error;
            }
            return error;
        }

        public async Task<ErrorResponse> AuthenticateAndAuthorize(ISANYUKTServiceUser serviceUser, bool validateBothToken = true, bool slidingExpiration = true, Permissions accessType = Permissions.NONE)
        {
            ErrorResponse error = await IsValidToken(serviceUser, validateBothToken, slidingExpiration);
            if (error.HasError)
            {
                return error;
            }
            //AUTHORIZATION
            if (accessType != Permissions.NONE)
            {
                error = await _customAuthorization.Authorize(serviceUser, accessType);
            }
            return error;
        }

        private async Task<ErrorResponse> IsValidToken(ISANYUKTServiceUser serviceUser, bool validateBothToken = true, bool slidingExpiration = true)
        {
            ErrorResponse error = new ErrorResponse();

            //If ValidateBothToken is false and still user token is received then it will be validated
            if (!validateBothToken && !string.IsNullOrEmpty(serviceUser.UserToken))
            {
                validateBothToken = true;
            }

            if (string.IsNullOrEmpty(serviceUser.ApiToken) || (validateBothToken && string.IsNullOrEmpty(serviceUser.UserToken)))
            {
                error.SetError(ErrorCodes.AUTHENTICATION_FAILURE);
                await ClearUserCacheAsync(serviceUser.ApiToken, serviceUser.UserToken);
                return error;
            }

            var isValid = await _authenticationProvider.IsValidToken(serviceUser.ApiToken, serviceUser.UserToken, validateBothToken, slidingExpiration);

            if (isValid)
            {
                error.NoError();
            }
            else
            {
                error.SetError(ErrorCodes.AUTHENTICATION_FAILURE);
                await ClearUserCacheAsync(serviceUser.ApiToken, serviceUser.UserToken);
            }

            return error;
        }

        private async Task ClearUserCacheAsync(string apiToken, string userToken)
        {
            if (!string.IsNullOrEmpty(apiToken))
                await MemoryCachingService.Clear(apiToken);

            if (!string.IsNullOrEmpty(userToken))
                await MemoryCachingService.Clear(userToken);
        }
    }
}
