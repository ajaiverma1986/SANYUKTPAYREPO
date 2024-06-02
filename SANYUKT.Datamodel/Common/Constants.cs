using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Datamodel.Common
{
    public static class SANYUKTClaimTypes
    {
        public const string UserMasterID = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/UserMasterID";
        public const string UserToken = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/userToken";
        public const string UserType = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/userType";
        public const string UserPermissions = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/userPermissions";
        public const string UserName = "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/userName";
    }

    public static class SANYUKTIssuer
    {
        public const string FIA = "urn:fiaglobal.com";
    }

    public struct CacheKeys
    {
        public const string STATIC_TABLE_DATA = "data:table:{0}";
        public const string APPLICATION_USER_DETAIL = "data:apitoken:{0}:applicationUserDetail";
        public const string USER_ROLES_API = "data:userToken:{0}:{1}:roles";
        public const string USER_ROLES_APP = "data:userToken:{0}:roles";
        public const string API_TOKEN = "data:apitoken";
        public const string APPLICATION_API_TOKEN = "data:apitoken";
        public const string ID = "data:id:{0}";
        public const string USERMASTER_ID = "data:userToken:{0}:userMasterID";
        public const string BLOCKED_IP = "data:blockedip";
    }

    public enum Permissions
    {
        NONE = 0,
        ACCESS_USERS = 1,
        UPDATE_USER_NON_CRITICAL = 2,
        UPDATE_USER_CRITICAL = 3,
        UPLOAD_KYC = 4,
        MANAGE_AGENT_PROFILE = 5,
        SEARCH_USERS = 6,
        ADD_USER = 7,
        ACCESS_ENROLLMENT = 8,
        MAP_ENROLLMENT_TYPE = 9,
        MAP_USER_ENROLLMENT_PAYMENT = 11,
        ACCESS_PAYMENTS = 12,
        LIMIT_TOP_UP = 13,
        LIMIT_SBI_KIOSK = 14,
        ACCESS_SYSTEM_CONFIG = 15,
        MODIFY_ACTIVE_SERVICES = 16,
        VIEW_ACTIVE_SERVICES = 17,
        CREATE_ENROLLMENT_TYPE = 18,
        DEFINE_ENROLLMENT_BREAKUP = 19,
        VIEW_ENROLLMENT_TYPES = 20,
        ACCESS_RECON = 21,
        IMPORT_RECON_FILES = 22,
        VIEW_RECON = 23,
        PROCESS_RECON = 24,
        VIEW_BATCHES = 25,
        VIEW_SUSPENSE = 26,
        ADD_PARENT = 27,
        PMT_MONEY_TRANSFER = 28,
        PANCARD_SERVICE = 29,
        ACCESS_INVOICING = 30,
        ADD_SEARCH_INVOICE = 31,
        VIEW_UPLOAD_KYC = 32,
        APPROVE_REJECT_UPLOAD_KYC = 33,
        ADD_LIMIT_TOP_UP = 34,
        SEARCH_LIMIT_TOP_UP = 35,
        APPROVE_REJECT_LIMIT_TOP_UP = 36,
        ADD_LIMIT_SBI_KIOSK = 37,
        VIEW_LIMIT_SBI_KIOSK = 38,
        SEARCH_LIMIT_SBI_KIOSK = 39,
        APPROVE_REJECT_LIMIT_SBI_KIOSK = 40,
        VIEW_LIMIT_TOP_UP = 41,
        SEARCH_BATCHES = 42,
        VIEW_BATCHE_SUMMARY = 43,
        VIEW_BATCH_ERROR = 44,
        SEARCH_SUSPENSE = 45,
        SEARCH_ACTIVE_SERVICE = 46,
        VIEW_AGENT_PROFILE = 47,
        MODIFY_ENROLLMENT = 48,
        MANAGE_PAYMENT_REQUEST = 50,
        SEARCH_ACTIVITY_LOG = 51,
        SEARCH_RECON_FILE_SUMMARY = 52,
        SEARCH_PRE_RECON_SUMMARY = 53,
        SEARCH_TRANSACTION_SUSPENSE = 54,
        RECON_ON_PROCESS = 55,
        MANAGE_RECON_SUSPENSE = 56,
        MANAGE_LIMIT_SBI_KIOSK = 57,
        VIEW_VENDOR_DETAIL = 58,
        MANAGE_VENDOR = 59,
        SEARCH_CSP_PAYMENT_ALLOCATION = 60,
        MANAGE_CSP_PAYMENT_ALLOCATION = 61,
        MODIFY_CSP_PAYMENT_ALLOCATION = 62,
        MANAGE_KIOSK_DETAIL = 64,
        MANAGE_ADDRESS_DETAIL = 65,
        EDIT_USER_FAMILY_DETAIL = 66,
        MANAGE_USER_GENRAL_DETAIL = 67,
        MANAGE_MANUAL_KNOCKOFF = 68,
        KYC_PROCESS = 100,
        ACCESS_SERVICE_PREAPAID = 101,
        ACESS_POSTPAID_SERVICE = 102,
        SEARCH_REQUEST = 103,
        CREATE_REQUEST = 104,
        ACCESS_UTILITYBILLPAY = 105,
        MANAGE_PARENT_MAPPING = 106,
        REQUEST_LIMIT = 107,
        VENDOR_LEDGER_SEARCH = 108,
        SBI_KIOSK_REQUEST_DOWNLOAD = 109,
        EDIT_USER_FIRST_MIDDLE_LAST_NAME = 110,
        VIEW_USER = 111,
        ACCOUNT_SEARCH = 112,
        VIEW_ACCOUNT = 113,
        ADD_ACCOUNT = 114,
        UPDATE_ACCOUNT_STATUS = 115,
        SEARCH_ADDRESS = 116,
        VIEW_ADDRESS = 117,
        SEARCH_AGENT = 118,
        UPDATE_AGENT_STATUS = 119,
        SEARCH_BANK = 120,
        VIEW_BANK = 121,
        UPDATE_BANK_STATUS = 123,
        SEARCH_BANK_STATEMENT = 124,
        VIEW_BANK_STATEMENT = 125,
        ADD_BANK_STATEMENT = 126,
        UPDATE_BANK_STATEMENT_STATUS = 127,
        SEARCH_BRANCH = 128,
        VIEW_BRANCH = 129,
        ADD_BRANCH = 130,
        UPDATE_BRANCH_STATUS = 131,
        SEARCH_BRAND = 132,
        VIEW_BRAND = 133,
        ADD_BRAND = 134,
        UPDATE_BRAND_STATUS = 135,
        SEARCH_DEVICE_CATEGORY = 136,
        VIEW_DEVICE_CATEGORY = 137,
        ADD_DEVICE_CATEGORY = 138,
        UPDATE_DEVICE_CATEGORY_STATUS = 139,
        SEARCH_DEVICE = 140,
        VIEW_DEVICE = 141,
        ADD_DEVICE = 142,
        UPDATE_DEVICE_STATUS = 143,
        SEARCH_DEVICE_MASTER = 144,
        VIEW_DEVICE_MASTER_DETAIL = 145,
        ADD_DEVICE_MASTER = 146,
        UPDATE_DEVICE_MASTER_STATUS = 147,
        SEARCH_DEVICE_USERMAPPING = 148,
        VIEW_DEVICE_USERMAPPING = 149,
        ADD_DEVICE_USERMAPPING = 150,
        UPDATE_DEVICE_USERMAPPING_STATUS = 151,
        SEARCH_DEVICE_WAREHOUSE_MAPPING = 152,
        VIEW_DEVICE_WAREHOUSE_MAPPING = 153,
        ADD_DEVICE_WAREHOUSE_MAPPING = 154,
        UPDATE_DEVICE_WAREHOUSE_MAPPING_STATUS = 155,
        SEARCH_ENROLLMENT_BREAKUPS = 156,
        VIEW_ENROLLMENT_BREAKSUPS = 157,
        ADD_ENROLLMENT_BREAKUPS = 158,
        SEARCH_ENROLLMENT = 159,
        VIEW_ENROLLMENT = 160,
        ADD_ENROLLMENT = 161,
        SEARCH_ENROLLMENTITEM = 162,
        ADD_ENROLLMENTITEM = 163,
        VIEW_ENROLLMENTITEM = 164,
        SEARCH_ENROLLMENT_PAYMENT = 165,
        VIEW_ENROLLMENT_PAYMENT = 166,
        ADD_ENROLLMENT_PAYMENT = 167,
        UPDATE_ENROLLMENT_PAYMENT_STATUS = 168,
        SEARCH_USER_FAMILY_DETAIL = 169,
        VIEW_USER_FAMILY_DETAIL = 170,
        ADD_USER_FAMILY_DETAIL = 171,
        SEARCH_KIOSK_DETAIL = 172,
        ADD_KIOSK_DETAIL = 173,
        VIEW_KIOSK_DETAIL = 174,
        UPDATE_KIOSK_STATUS = 175,
        SEARCH_PAYMENT_REQUEST = 176,
        VIEW_PAYMENT_REQUEST = 177,
        ADD_PAYMENT_REQUEST = 178,
        UPDATE_PAYMENT_REQUEST_STATUS = 179,
        DOWNLOAD_SBI_KIOSK_REQUEST = 180,
        SEARCH_KIOSK_DOWNLOAD_REQUEST = 181,
        SEARCH_PURCHASE_ORDER = 182,
        VIEW_PURCHASE_ORDER = 183,
        ADD_PURCHASE_ORDER = 184,
        UPDATE_PURCHASE_ORDER_STATUS = 185,
        SEARCH_PURCHASE_ORDER_PAYMENT = 186,
        VIEW_PURCHASE_ORDER_PAYMENT = 187,
        ADD_PURCHASE_ORDER_PAYMENT = 188,
        UPDATE_PURCHASE_ORDER_PAYMENT = 189,
        SEARCH_PURCHASE_REQUEST = 190,
        VIEW_PURCHASE_REQUEST = 191,
        ADD_PURCHASE_REQUEST = 192,
        UPDATE_PURCHASE_REQUEST_STATUS = 193,
        SEARCH_USER_ENROLLMENT = 194,
        VIEW_USER_ENROLLMENT = 195,
        ADD_USER_ENROLLMENT = 196,
        UPDATE_USER_ENROLLMENT_STATUS = 197,
        SEARCH_SBIKO_REGISTRATION = 198,
        ADD_SBIKO_REGISTRATION = 199,
        SEARCH_AMOUNT_DETAIL = 200,
        SERVICE_PREPAID = 201,
        SERVICE_BILL_PAYMENT = 202,
        SERVICE_PMT = 203,
        SERVICE_DMT = 204,
        SERVICE_LIMIT_TOP_UP = 205,
        SERVICE_LIMIT_SBI_KIOSK = 206,
        NATURE_CUBE = 207,
        SEARCH_VENDOR = 208,
        VIEW_VENDOR = 209,
        ADD_VENDOR = 210,
        UPDATE_VENDOR_STATUS = 211,
        SEARCH_WAREHOUSE = 212,
        VIEW_WAREHOUSE = 213,
        ADD_WAREHOUSE = 214,
        UPDATE_WAREHOUSE_STATUS = 215,
        ACCESS_PROCUREMENT = 216,
        SEARCH_SHIPMENT = 217,
        ADD_SHIPMENT = 218,
        ADD_SHIPMENT_ITEM = 219,
        RECON_SUMMARY_TXN = 220,
        RECON_VENDOR_LEDGER = 221,
        SEARCH_SUPERADMIN = 222,
        MANAGE_DELIVERY_ADDRESS = 223,
        ACCESS_AUDIT = 229,
        SWACHATA = 230,
        SERVICE_AUDIT = 231,
        UPLOAD_KYC_MOBILE = 232,
        SEARCH_POLICY_PLAN = 233,
        ADD_POLICYPLAN = 234,
        ACCESS_LIC_SERVICE = 235,
        IMPORT_USERS = 236,
        REJECT_APPROVED_DOCUMENT = 237,
        APPROVE_DOCUMENT = 238,
        SEARCH_TRANSACTION_TYPE = 239,
        SEARCH_SUBTRANSACTION_TYPE = 240,
        SEARCH_SUBTRANSACTION_GROUP = 241,
        SEARCH_BANK_SUBTRANSACTION_MAPPING = 242,
        ADD_BANK = 245,
        MANAGE_BANK = 246,
        SEARCH_BankSubTransactionMapping = 247,
        VIEW_BankSubTransactionMapping = 248,
        MANAGE_BankSubTransactionMapping = 249,
        UPDATE_BankSubTransactionMapping_STATUS = 250,
        SREACH_SUSPENSE = 251,
        SEARCH_VENDOR_LEDGER = 252,
        SEARCH_TRANSACTION_SUMMARY = 253,
        SEARCH_CASH_HOLDING_SUMMARY = 254,
        SEARCH_APY_TRANSACTION = 255,
        SEARCH_SERVICE_CATEGORY = 256,
        VIEW_SERVICE_CATEGORY = 257,
        MANAGE_SERVICE_CATEGORY = 258,
        UPDATE_SERVICE_CATEGORY = 259,
        SEARCH_SERVICE = 260,
        VIEW_SERVICE = 261,
        ADD_SERVICE = 262,
        UPDATE_SERVICE_STATUS = 263,
        SEARCH_SERVICE_TYPE = 264,
        VIEW_SERVICETYPE = 265,
        ADD_SERVICETYPE = 266,
        UPDATE_SERVICETYPE_STATUS = 267,
        VIEW_TRANSACTION_TYPE = 268,
        ADD_TRANSACTION_TYPE = 269,
        UPDATE_TRANSACTION_TYPE_STATUS = 270,
        VIEW_SUBTRANSACTION_TYPE = 271,
        ADD_SUBTRANSACTION_TYPE = 272,
        SEARCH_USERIMPORT = 273,
        UPDATE_USERIMPORT_STATUS = 274,
        ADD_SERVICEMARGIN = 275,
        VIEW_SERVICEMARGIN = 276,
        SEARCH_SERVICEMARGIN = 277,
        SEARCH_USERS_ROLES = 278,
        ADD_USERS_ROLES = 279,
        VIEW_USERS_ROLES = 280,
        UPDATE_USERS_ROLES_STATUS = 281,
        SEARCH_ROLEPERMISSION = 282,
        VIEW_ROLEPERMISSION = 283,
        ADD_ROLEPERMISSION = 284,
        UPDATE_ROLEPERMISSION_STATUS = 285,
        SEARCH_ROLE = 286,
        VIEW_ROLE = 287,
        ADD_ROLE = 288,
        UPDATE_ROLE_STATUS = 289,
        SEARCH_PERMISSION = 290,
        VIEW_PERMISSION = 291,
        ADD_PERMISSION = 292,
        UPDATE_STATUS_PERMISSION = 293,
        SEARCH_MENU = 294,
        VIEW_MENU = 295,
        ADD_MENU = 296,
        UPDATE_STATUS_MENU = 297,
        SEARCH_MENU_PERMISSION = 298,
        VIEW_MENU_PERMISSION = 299,
        ADD_MENU_PERMISSION = 300,
        UPDATE_STATUS_MENU_PERMISSION = 301,
        SEARCH_MODULE = 302,
        VIEW_MODULE = 303,
        ADD_MODULE = 304,
        UPDATE_STATUS_MODULE = 305,
        SEARCH_COUNTRY = 306,
        VIEW_COUNTRY = 307,
        ADD_COUNTRY = 308,
        UPDATE_STATUS_COUNTRY = 309,
        SEARCH_STATE = 310,
        VIEW_STATE = 311,
        ADD_STATE = 312,
        UPDATE_STATUS_STATE = 313,
        SEARCH_REGION = 314,
        VIEW_REGION = 315,
        ADD_REGION = 316,
        UPDATE_STATUS_REGION = 317,
        SEARCH_TOWN = 318,
        VIEW_TOWN = 319,
        ADD_TOWN = 320,
        UPDATE_STATUS_TOWN = 321,
        SEARCH_VILLAGE = 322,
        VIEW_VILLAGE = 323,
        ADD_VILLAGE = 324,
        UPDATE_STATUS_VILLAGE = 325,
        SEARCH_GRAMPANCHAYAT = 326,
        VIEW_GRAMPANCHAYAT = 327,
        ADD_GRAMPANCHAYAT = 328,
        UPDATE_STATUS_GRAMPANCHAYAT = 329,
        SEARCH_DISTRICT = 330,
        VIEW_DISTRICT = 331,
        ADD_DISTRICT = 332,
        UPDATE_STATUS_DISTRICT = 333,
        SEARCH_SUBDISTRICT = 334,
        VIEW_SUBDISTRICT = 335,
        ADD_SUBDISTRICT = 336,
        UPDATE_STATUS_SUBDISTRICT = 337,
        SEARCH_COMPANYTYPE = 338,
        VIEW_COMPANYTYPE = 339,
        ADD_COMPANYTYPE = 340,
        UPDATE_STATUS_COMPANYTYPE = 341,
        SEARCH_COMPETITORS = 342,
        VIEW_COMPETITORS = 343,
        ADD_COMPETITORS = 344,
        UPDATE_STATUS_COMPETITORS = 345,
        ACCESS_SIGNON_COMMISSIONMAPPING = 346,
        CREATE_USER = 347,
        ACCESS_RECONSYSTEM = 348,
        SEARCH_AuditAction = 349,
        VIEW_AuditAction = 350,
        ADD_AuditAction = 351,
        UPDATE_AuditAction_STATUS = 352,
        SEARCH_NOTIFICATION_CATEGORY = 353,
        VIEW_NOTIFICATION_CATEGORY = 354,
        ADD_NOTIFICATION_NOTIFICATION = 355,
        UPDATE_STATUS_NOTIFICATION_CATEGORY = 356,
        SEARCH_NOTIFICATION_TEMPLATES = 357,
        VIEW_NOTIFICATION_TEMPLATES = 358,
        ADD_NOTIFICATION_TEMPLATES = 359,
        UPDATE_STATUS_NOTIFICATION_TEMPLATES = 360,
        SEARCH_NOTIFICATION_CONFIG = 361,
        VIEW_NOTIFICATION_CONFIG = 362,
        ADD_NOTIFICATION_CONFIG = 363,
        UPDATE_STATUS_NOTIFICATION_CONFIG = 364,
        SEARCH_NOTIFICATION_LOG = 365,
        SEARCH_EMAILGATEWAY = 366,
        VIEW_EMAILGATEWAY = 367,
        ADD_EMAILGATEWAY = 368,
        UPDATE_STATUS_EMAILGATEWAY = 369,
        ADMIN_ADD_PAYMENTREQUEST = 370,
        SEARCH_SERVICE_MAPPING = 371,
        VIEW_SERVICE_MAPPING = 372,
        ADD_SERVICE_MAPPING = 373,
        UPDATE_SERVICE_MAPPING_STATUS = 374,
        Access_NOTIFICATION = 375,
        ACCESS_GEOGRAPHY = 376,
        ACCESS_SUMMARY = 377,
        ACCESS_KYC = 378,
        KYC_DOWNLOAD = 379,
        ACCESS_KYC_STATUS_REPORT = 380,
        DOWNLOAD_KYC_STATUS_REPORT = 381,
        SEARCH_SMSGATEWAY = 382,
        VIEW_SMSGATEWAY = 383,
        ADD_SMSGATEWAY = 384,
        UPDATE_STATUS_SMSGATEWAY = 385,
        SEARCH_KYC_REPORT = 386,
        SEARCH_KYC_STATUS_REPORT = 387,
        DOWNLOAD_kYC_REPORT = 388,
        VIEW_KYC_REPORT = 389,
        CREATE_SHORT_PAYMENT = 390,
        EDIT_SHORT_PAYMENT = 391,
        APPROVE_REJECT_SHORT_PAYMENT = 392,
        REJECT_SHORT_PAYMENT = 393,
        ACCESS_SHORT_PAYMENT = 394,
        APPROVE_REJECT_WAVER = 395,
        REJECT_WAVER = 396,
        EDIT_WAVER = 397,
        CREATE_WAVER = 398,
        EDIT_PAYMENT = 399,
        SEARCH_PAYMENT_USER = 400,
        SEARCH_WAVER = 401,
        SEARCH_SHORT = 402,
        SAVE_SHORT = 403,
        ACCESS_REPORT_MANEGER = 406,
        SEARCH_REPORT_MANEGER = 408,
        APPROVE_REJECT_PURCHASE_REQUEST = 409
    }

    public enum NotificationTemplate
    {
        USER_CREATED = 1,
        PASSWORD_CHANGED = 2
    }

    [Flags]
    public enum NotificationMediumType
    {
        Email = 2,
        SMS = 4,
        InApp = 8
    }

    public enum NotificationLogStatus
    {
        Pending = 1,
        Queue = 2,
        Error = 3,
        Sent = 4
    }


    /// <summary>
    /// Regular expression for contracts
    /// </summary>
    public struct RegularExpression
    {
        public const string ALPHABETS = @"^[A-z]+$";
        public const string NUMERIC = @"^[0-9]*$";
        public const string DECIMAL = @"^((\d+)((\.\d{1,4})?))$";
        public const string MOBILE_NUMBER = @"^[6789]\d{9}$";
        public const string LANDLINE_NUMBER = @"^(?!0+$)[0-9]\d{8,10}$";
        public const string EMAIL = "^[A-z0-9_\\+-]+(\\.[A-z0-9_\\+-]+)*@[A-z0-9-]+(\\.[A-z0-9]+)*\\.([A-z]{2,4})$";
        public const string PASSWORD = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&_])[A-Za-z\d$@$!%*#?&_]{6,20}$";
        //public const string URL = @"^((http[s]?|ftp):\/)?\/?([^:\/\s]+)((\/\w+)*\/)([\w\-\.]+[^#?\s]+)(.*)?(#[\w\-]+)?$";
        public const string URL = @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$";

        //^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$

        public const string PAN_CARD = @"^[A-Z]{5}[0-9]{4}[A-Z]{1}$";
        public const string AADHAR_CARD = @"^(?!0+$)[0-9]{12}$";
        public const string PINCODE = @"^(?!0+$)[1-9][0-9]{5}$";
        public const string IFSC_CODE = @"^[A-Z]{4}0[A-Z0-9]{6}$";
        public const string BANK_ACCOUNT_NUMBER = @"^(?!0+$)[0-9]{9,18}$";
        public const string BCCertificate = @"^(?!0+$)[0-9]{12}$";
        public const string DRACertificate = @"^(?!0+$)[0-9]{12}$";
        public const string GST_NUMBER = @"\d{2}[A-Z]{5}\d{4}[A-Z]{1}\d[Z]{1}[A-Z\d]{1}";

        public const string NameWithBrackets = "^[a-zA-Z][A-Za-z\\s0-9-.()$\\s]+$";
        public const string AN_SPACE_WITHSMALLBRACKETCHARCTERS = @"^[a-zA-Z()\s]+$";
        public const string AN_NOSPACE_SPECIALCHARCTERS = @"^[a-zA-Z.,0-9_./\\\-]+$";
        public const string AN_SPACE_SPECIALCHARCTERS = @"^(?!\s*$)[a-zA-Z.,0-9\s_./\\\-]+$";
        public const string AN_USERNAME_SPECIALCHARCTERS = @"^[a-zA-Z.0-9@_.-]{6,50}$";
        public const string AN_SPACE_NOSPECIALCHARCTERS = @"^[a-zA-Z0-9' '&]+$";
        public const string AN_SPACE_NOSPECIALCHARCTERSWITHOUTNUMBERS = @"^[a-zA-Z' '.&]+$";
        public const string AN_NOSPACE = @"^[a-zA-Z0-9]+$";
        public const string ADDRESS = @"^(?!0+$)[a-zA-Z.,0-9@\s_&#./\\\-]+$";
        public const string AN_SPACE_ALPHABETS = @"^[a-zA-Z' ']+$";
        public const string AN_ADDRESS = @"^(?!0+$)[a-zA-Z.,0-9@&,\s_./\\\-]+$";
        public const string AN_ALPHABETS_WITHDOT = @"^[a-zA-Z.]+$";
        public const string AN_ALPHABETS_WITH_UNDERSCORE = @"^[a-zA-Z_]+$";
        public const string AN_SPACE_ALPHABETS_WITHDOT = @"^(?!\s*$)[a-zA-Z' '.]+$";
        public const string SPACE_WITH_OTHER_CHARACTERS = @"^(?!\s*$).+";
        public const string ALPHA_WITH_NUMERIC_ONLY = @"^(?![0-9]*$)(?![a-zA-Z]*$)[a-zA-Z0-9]+$";
        public const string ALPHA_NUMERIC_ONLY = @"^(?!0+$)[a-zA-Z0-9]*";
        public const string AN_DECIMAL_NOT_START_END_WITH_DOT = @"^(0|[1-9]\d*)(\.\d+)?$";
        public const string LATITUDE = @"^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$";
        public const string LONGITUDE = @"^(\+|-)?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,6})?))$";
    }
    public struct AppSetting
    {
        public const string No_Of_Request_Allowed_InDay = "No_Of_Request_Allowed_InDay";
        public const string Max_Allowed_SBI_Kiosk_Request_Limit = "Max_Allowed_SBI_Kiosk_Request_Limit";
        public const string SEQUENCE_ENROLLMENT = "SEQUENCE_ENROLLMENT";
        public const string SEQUENCE_ENROLLMENT_CURRENT_DATE = "SEQUENCE_ENROLLMENT_CURRENT_DATE";
        public const string SEQUENCE_PAYMENTREQUEST = "SEQUENCE_PAYMENTREQUEST";
        public const string SEQUENCE_PAYMENTREQUEST_CURRENT_DATE = "SEQUENCE_PAYMENTREQUEST_CURRENT_DATE";
        public const string COMMISSION_LAST_UPDATE = "COMMISSION_LAST_UPDATE";
        public const string BT_CSP_ID_LAST_UPDATE = "BT_CSP_ID_LAST_UPDATE";
        public const string SEQUENCE_INVOICE = "SEQUENCE_INVOICE";
        public const string SEQUENCE_INVOICE_CURRENT_DATE = "SEQUENCE_INVOICE_CURRENT_DATE";
        public const string SEQUENCE_TRANSACTION = "SEQUENCE_TRANSACTION";
        public const string SEQUENCE_TRANSACTION_CURRENT_DATE = "SEQUENCE_TRANSACTION_CURRENT_DATE";
        public const string Invoice_File_Monitor_Interval_In_Min = "Invoice_File_Monitor_Interval_In_Min";
        public const string Data_Sync_Monitor_Interval_In_Min = "Data_Sync_Monitor_Interval_In_Min";
        public const string OldData_Sync_Monitor_Interval_In_Min = "OldData_Sync_Monitor_Interval_In_Min";

    }
}
