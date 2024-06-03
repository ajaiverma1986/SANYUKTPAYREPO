using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Datamodel.Common
{
    public enum ApplicationTypes
    {
        [Display(Name = "FIA Admin")]
        FIAAdmin = 1,
        [Display(Name = "FIA Reconciliation")]
        FIAReconciliation = 2,
        [Display(Name = "FIA MobileAPI")]
        FIAMobileAPI = 3,
        [Display(Name = "FIA Billpay")]
        FIABillpay = 4,
        [Display(Name = "Automated Jobs")]
        Jobs = 5
    }
    [Flags]
    public enum SQLParamPlaces
    {
        Default = Reader | Writer,
        None = 2,
        Reader = 4,
        Writer = 8
    }
}
