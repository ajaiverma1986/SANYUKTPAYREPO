using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //UserMasterID = datareaderhelper.Instance.GetDataReaderNullableValue_Int(reader, "UserMasterID");

            //Password = datareaderhelper.Instance.GetDataReaderNullableValue_String(reader, "Password");

            //PanCard = datareaderhelper.Instance.GetDataReaderNullableValue_String(reader, "PanCard");

            //EmailID_MobileNo = datareaderhelper.Instance.GetDataReaderNullableValue_String(reader, "EmailID_MobileNo");

            //Status = datareaderhelper.Instance.GetDataReaderNullableValue_Int(reader, "Status");

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


            //usermasterid = datareaderhelper.instance.getdatareadernullablevalue_int(reader, "usermasterid");

            //username = datareaderhelper.instance.getdatareadernullablevalue_string(reader, "username");

            //displayname = datareaderhelper.instance.getdatareadernullablevalue_string(reader, "displayname");

            //pancard = datareaderhelper.instance.getdatareadernullablevalue_string(reader, "pancard");

            //email = datareaderhelper.instance.getdatareadernullablevalue_string(reader, "email");

            //mobile = datareaderhelper.instance.getdatareadernullablevalue_string(reader, "mobile");



            //Password = DataReaderHelper.Instance.GetDataReaderNullableValue_String(reader, "Password");

            //Status = DataReaderHelper.Instance.GetDataReaderNullableValue_Int(reader, "Status");

            //CreatedOn = DataReaderHelper.Instance.GetNullDataReaderValue_DateTime(reader, "CreatedOn");

            //CreatedBy = DataReaderHelper.Instance.GetDataReaderNullableValue_Int(reader, "CreatedBy");

            //UpdateOn = DataReaderHelper.Instance.GetNullDataReaderValue_DateTime(reader, "UpdateOn");

            //UpdateBy = DataReaderHelper.Instance.GetDataReaderNullableValue_Int(reader, "UpdateBy");
        }
    }
}
