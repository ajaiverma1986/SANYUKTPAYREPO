using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SANYUKT.CommonLib
{
    public class DropDownListValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (Convert.ToInt32(value) > 0) ? true : false;
        }
    }
}
