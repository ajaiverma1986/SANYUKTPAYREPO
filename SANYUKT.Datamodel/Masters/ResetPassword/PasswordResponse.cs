using SANYUKT.Datamodel.Library;
using System.Data.SqlClient;


namespace SANYUKT.Datamodel.Masters.ResetPassword
{
    public class PasswordResponse
    {

        public int? UserMasterID { get; set; }

        public string Password { get; set; }

        public string PanCard { get; set; }

        public string EmailID_MobileNo { get; set; }

        public int? Status { get; set; }

        public void FromReader(SqlDataReader reader)
        {

            UserMasterID = DataReaderHelper.Instance.GetDataReaderNullableValue_Int(reader, "usermasterid");

            Password = DataReaderHelper.Instance.GetDataReaderNullableValue_String(reader, "password");

            PanCard = DataReaderHelper.Instance.GetDataReaderNullableValue_String(reader, "pancard");

            EmailID_MobileNo = DataReaderHelper.Instance.GetDataReaderNullableValue_String(reader, "emailid_mobileno");

            Status = DataReaderHelper.Instance.GetDataReaderNullableValue_Int(reader, "status");

        }
    }



    public class ForgetPasswordResponse
    {

        public int? UserMasterID { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string PanCard { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }


        public void FromReader(SqlDataReader reader)
        {


            UserMasterID = DataReaderHelper.Instance.GetDataReaderNullableValue_Int(reader, "usermasterid");

            UserName = DataReaderHelper.Instance.GetDataReaderNullableValue_String(reader, "username");

            DisplayName = DataReaderHelper.Instance.GetDataReaderNullableValue_String(reader, "displayname");

            PanCard = DataReaderHelper.Instance.GetDataReaderNullableValue_String(reader, "pancard");

            Email = DataReaderHelper.Instance.GetDataReaderNullableValue_String(reader, "email");

            Mobile = DataReaderHelper.Instance.GetDataReaderNullableValue_String(reader, "mobile");


        }
    }
}
