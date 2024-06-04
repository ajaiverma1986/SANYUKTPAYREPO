using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Datamodel.Shared
{
    public class SimpleResponse : BaseResponse
    {
        public object Result { get; set; }
    }
    public class SimpleResponse1 : BaseResponse
    {
        public object result { get; set; }
    }

    public class AgentResponse : BaseResponse
    {
        public object Result { get; set; }
        public string TransactionId { get; set; }
    }

    public class EncryptedResponse
    {
        public EncryptedResponse()
        {
            this.ResMsg = string.Empty;
            this.Status = "Failure";
        }
        public string ResMsg { get; set; }
        public string Status { get; set; }
    }

    public class DigiGoldResponse : BaseResponse
    {
        public object Result { get; set; }
        public string CustomerId { get; set; }

    }
}
