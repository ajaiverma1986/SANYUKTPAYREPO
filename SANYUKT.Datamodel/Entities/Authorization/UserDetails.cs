using SANYUKT.Datamodel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Datamodel.Entities.Authorization
{
    public class UserDetails
    {
        public long UserMasterID { get; set; }
        public int UserType { get; set; }
        public int MDSType { get; set; }
        public int DSType { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string PanCard { get; set; }
        public string AadharCard { get; set; }
        public string RelationType { get; set; }
        public UserMasterStatus Status { get; set; }

    }
}
