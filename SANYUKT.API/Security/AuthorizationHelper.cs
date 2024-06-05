using SANYUKT.Commonlib.Cache;
using SANYUKT.Datamodel.Common;
using SANYUKT.Datamodel.Entities.Authorization;
using SANYUKT.Datamodel.Interfaces;
using SANYUKT.Datamodel.Shared;

namespace SANYUKT.API.Security
{
    public class AuthorizationHelper
    {
        public AuthorizationHelper()
        {
        }

        public async Task<ErrorResponse> Authorize(ISANYUKTServiceUser serviceUser, Permissions permission)
        {
            ErrorResponse error = new ErrorResponse();

            if (permission == Permissions.NONE)
            {
                error.SetError(ErrorCodes.NO_ERROR);
            }
            else
            {
                List<UserApplicationAccessPermissions> userPermissions = await MemoryCachingService.Get<List<UserApplicationAccessPermissions>>(string.Format(CacheKeys.USER_ROLES_API, serviceUser.ApplicationID, serviceUser.UserToken));
                if (userPermissions == null || userPermissions.Count == 0)
                {
                    error.SetError(ErrorCodes.AUTHORIZATION_FAILURE);
                }
                else
                {
                    UserApplicationAccessPermissions userApplicationAccess = (from access in userPermissions where access.PermissionID == permission select access).FirstOrDefault();
                    if (userApplicationAccess == null)
                    {
                        error.SetError(ErrorCodes.AUTHORIZATION_FAILURE);
                    }
                }
            }
            return error;
        }
    }
}
