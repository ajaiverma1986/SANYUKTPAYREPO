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
    public enum ActivityEnum
    {
        [Display(Name = "User Registered")]
        USER_REGISTERED = 1,
        [Display(Name = "Reference Number Generated")]
        REFERENCE_NUMBER_GENERATED = 2,
        [Display(Name = "CSP Code Created")]
        CSP_CODE_CREATED = 3,
        [Display(Name = "CSP Code Successfully Activated")]
        CSP_CODE_ACTIVATED = 4,
        [Display(Name = "CSP Code Deleted")]
        CSP_CODE_DELETED = 5,
        [Display(Name = "CSP Activated")]
        CSP_ACTIVATED = 6,
        [Display(Name = "CSP Rejected")]
        CSP_REJECTED = 7,
        [Display(Name = "CSP Dormant")]
        CSP_DORMANT = 8,
        [Display(Name = "CSP Inactive")]
        CSP_INACTIVE = 9,
        [Display(Name = "CSP Code Marked For Deletion")]
        CSP_MARKED_FOR_DELETION = 10,
        [Display(Name = "Payment Request Updation")]
        PAYMENT_REQUEST = 11,
        [Display(Name = "Document Status")]
        DOCUMENT_STATUS = 12,
        [Display(Name = "CSP Code Pending")]
        CSP_CODE_PENDING = 13,
        [Display(Name = "Device Confirmation Date")]
        DEVICE_CONFIRMATION_DATE = 14,
        [Display(Name = "Device Activation Date")]
        DEVICE_ACTIVATION_DATE = 15,
        [Display(Name = "Fingure Print Capture Date")]
        FINGERPRINT_CAPTURE_DATE = 16,
        [Display(Name = "Terminal Mapping Activation Date")]
        TERMINALMAPPING_ACTIVATION_DATE = 17,
        [Display(Name = "Terminal Mapping Done By Bank")]
        TERMINALMAPPING_DONEBYBANK_DATE = 18,
        [Display(Name = "RD Renewal Date")]
        RDRENEWAL_DATE = 19,
        [Display(Name = "RD Expiry Date")]
        RDEXPIRY_DATE = 20,
        [Display(Name = "Date Of Creation")]
        DATE_OF_CREATION = 21,
        [Display(Name = "CSP Code Received Date")]
        CSP_CODE_RECEIVED_DATE = 22,
        [Display(Name = "CSP Code Configure Date")]
        CSP_CODE_CONFIGURE_DATE = 23,
        [Display(Name = "Channel DB Update Date")]
        CHANNEL_DB_UPDATE_DATE = 24,
        [Display(Name = "WealthManager Approved Date")]
        WEALTHMANAGER_APPROVED_DATE = 25,
        [Display(Name = "AECS Code Created")]
        AECS_CODE_CREATED = 26,
        [Display(Name = "AECS Code Successfully Activated")]
        AECS_CODE_ACTIVATED = 27,
        [Display(Name = "AECS Code Deleted")]
        AECS_CODE_DELETED = 28,
        [Display(Name = "AECS Activated")]
        AECS_ACTIVATED = 29,
        [Display(Name = "AECS Rejected")]
        AECS_REJECTED = 30,
        [Display(Name = "AECS Dormant")]
        AECS_DORMANT = 31,
        [Display(Name = "AECS Inactive")]
        AECS_INACTIVE = 32,
        [Display(Name = "AECS Code Marked For Deletion")]
        AECS_MARKED_FOR_DELETION = 33,
        [Display(Name = "AECS Code Pending")]
        AECS_CODE_PENDING = 34,
    }
    public enum UserMasterStatus
    {
        [Display(Name = "Pending with field Team")]
        Draft = 1,
        [Display(Name = "KYC Pending")]
        KycPending = 2,
        [Display(Name = "Code Pending")]
        CodePending = 3,
        [Display(Name = "Sign-on Pending")]
        SignonPending = 4,
        [Display(Name = "FID Status Pending")]
        FIDStatusPending = 5,
        [Display(Name = "Backened Activation Pending")]
        BackenedActivationPending = 6,
        [Display(Name = "Frontend Activation Pending")]
        FrontendActivationPending = 7,
        [Display(Name = "Activated")]
        Activated = 8,
        [Display(Name = "Rejected")]
        Rejected = 9,
        [Display(Name = "Dormant")]
        Dormant = 10,
        [Display(Name = "Deactivated")]
        Deactivated = 11,
        [Display(Name = "Terminated")]
        Terminated = 12

    }
}
