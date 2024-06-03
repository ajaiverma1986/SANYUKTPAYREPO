using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Logging
{
    public class Log
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public string LoggingLevel { get; set; }
        public string UserToken { get; set; }
        public Int64? UserMasterID { get; set; }
        public string ApiToken { get; set; }
        public string ModuleName { get; set; }
        public string ApplicationName { get; set; }
        public int? ApplicationId { get; set; }
        public string IpAddress { get; set; }
        public string Url { get; set; }
        public string ReferrerUrl { get; set; }
        public string Headers { get; set; }
        public string MoreInfo { get; set; }
    }
}
