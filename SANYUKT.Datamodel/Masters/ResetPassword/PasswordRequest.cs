using SANYUKT.Datamodel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Datamodel.Masters.ResetPassword
{
    public class PasswordRequest : ListRequest
    {


        public int UserLogID { get; set; }

        public int? UserMasterID { get; set; }

        public string Password { get; set; }

        public string PanCard { get; set; }

        public string EmailID_MobileNo { get; set; }

        public int? Status { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? UpdateOn { get; set; }

        public int? UpdateBy { get; set; }



    }

    public class forgetpasswordrequest : ListRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PanCard { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
    }
}
