using Microsoft.AspNetCore.Authorization;
using SANYUKT.Datamodel.Common;



namespace SANYUKT.Commonlib.Security
{
    public class CustomAuthorizationRequirement : IAuthorizationRequirement
    {
        public Permissions Permission { get; set; }
    }
}
