using SANYUKT.Datamodel.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Datamodel.Common
{
    public class SANYUKTServiceUser : ISANYUKTServiceUser
    {
        public string UserToken { get; set; }

        public string ApiToken { get; set; }

        public Int64? UserMasterID { get; set; }

        public Int32? OrganizationID { get; set; }

        public Int32? WorkOrganizationID { get; set; }

        public string ApplicationName { get; set; }

        public int ApplicationID { get; set; }

        public string IPAddress { get; set; }

        public string RequestUrl { get; set; }

        public string ReferrerUrl { get; set; }

        public string Headers { get; set; }

        public string ClientIPAddress { get; set; }

        public ApplicationTypes AppType { get; set; }

        public void GenerateSQLParams(SqlCommand cmd)
        {
            AddInParameter(cmd, "@UserMasterID", UserMasterID);
        }

        private void AddInParameter(SqlCommand dbCommand, string parameterName, object value)
        {
            object finalVal = value;

            if (value == null)
                finalVal = DBNull.Value;
            else
            {
                if (value.GetType() == typeof(string))
                {
                    if (string.IsNullOrEmpty((string)value))
                    {
                        finalVal = DBNull.Value;
                    }
                }
            }
            dbCommand.Parameters.AddWithValue(parameterName, finalVal);
        }
    }
}
