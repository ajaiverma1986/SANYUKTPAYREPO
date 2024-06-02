using Microsoft.AspNetCore.Authorization;
using SANYUKT.Datamodel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SANYUKT.Commonlib.Security
{
    public class CustomAuthorizationRequirement : IAuthorizationRequirement
    {
        public Permissions Permission { get; set; }
    }
}
