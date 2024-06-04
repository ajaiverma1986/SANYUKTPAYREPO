using SANYUKT.Datamodel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Datamodel.Entities.Authorization
{
    public class UserApplicationAccessPermissions
    {
        public Int32 RoleID { get; set; }
        public Permissions PermissionID { get; set; }
        public Int32 ApplicationID { get; set; }
        public Int32 UserMasterID { get; set; }
    }
}
