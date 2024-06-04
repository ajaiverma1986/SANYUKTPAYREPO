using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Datamodel.DTO.Request
{
    public class UserLoginRequest
    {
        
        private string userName;

        public string Username
        {
            get { return userName.Trim().ToUpper(); }
            set { userName = value.Trim().ToUpper(); }
        }

        
        public string Password { get; set; }

    }

    public class UserChangePasswordRequest
    {

       
        public string OldPassword { get; set; }

        
        public string Password { get; set; }
    }

    public class ResetPasswordRequest
    {
        
        public string Token { get; set; }

        public UserChangePasswordRequest PasswordRequest { get; set; }
    }

    public class ResetPasswordRequestOTP
    {

        public long UserMasterID;
       
        public string Token { get; set; }
        
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }


   
}
