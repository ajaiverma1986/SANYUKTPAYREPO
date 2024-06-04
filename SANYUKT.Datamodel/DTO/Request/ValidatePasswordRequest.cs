using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Datamodel.DTO.Request
{
    public class ValidatePasswordRequest
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

    }
}
