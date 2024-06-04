using SANYUKT.Datamodel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Datamodel.Entities.Application
{
    public class ApplicationUserMappingResponse
    {
        public string ApplicationName { get; set; }
        public int ApplicationId { get; set; }
        public Int32? UserMasterID { get; set; }

        public Int32? OrganizationID { get; set; }

        public ApplicationTypes AppType { get; set; }
    }
}
