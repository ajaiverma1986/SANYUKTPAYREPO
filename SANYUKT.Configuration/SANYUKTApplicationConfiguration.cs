using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace SANYUKT.Configuration
{
    public class SANYUKTApplicationConfiguration
    {
        private static readonly SANYUKTApplicationConfiguration instance = new SANYUKTApplicationConfiguration();
        private static IHostingEnvironment _HostingEnvironment = null;
        private static IConfigurationRoot configuration = null;

        private SANYUKTApplicationConfiguration()
        {
        }

        static SANYUKTApplicationConfiguration()
        {
            IConfigurationBuilder builder = null;

            //if (File.Exists(Directory.GetCurrentDirectory() + "\\" + "appsettings.development.json"))
            //    builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true);
            //else
            //    builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
        }


        public static SANYUKTApplicationConfiguration Instance
        {
            get
            {
                return instance;
            }
        }

        public string FIADB
        {
            get
            {
                return configuration.GetConnectionString("FIADB");
            }
        }

        public string FIABillBayDB
        {
            get
            {
                return configuration.GetConnectionString("FIABillBayDB");
            }
        }

        public string FIACSPDBCon
        {
            get
            {
                return configuration.GetConnectionString("FIACSPDB");

            }
        }
        public string BaseClientAssetsURL
        {
            get
            {
                return configuration["BaseClientAssetsURL"];
            }
        }

        public string FIANotificationDB
        {
            get
            {
                return configuration.GetConnectionString("FIANotificationDB");
            }
        }

        public string FIAReconciliationDB
        {
            get
            {
                return configuration.GetConnectionString("FIARECONDB");
            }
        }

        public string FIABillPayMigrationDB
        {
            get
            {
                return configuration.GetConnectionString("BillPayMigrationDB");
            }
        }

        public string FIAALPHAReconciliationDB
        {
            get
            {
                return configuration.GetConnectionString("FIAALPHARECONDB");
            }
        }
        public string FIACTRLS
        {
            get
            {
                return configuration.GetConnectionString("FIACTRLS");
            }
        }

        public string AuditingDB
        {
            get
            {
                return configuration.GetConnectionString("AuditingDB");
            }
        }

        public string LoggingDB
        {
            get
            {
                return configuration.GetConnectionString("LoggingDB");
            }
        }

        public string FIAAPIUrl
        {
            get
            {
                return configuration["FIAAPIUrl"];
            }
        }

        public string MediaAllowedFormats
        {
            get
            {
                return configuration["MediaAllowedFormats"];
            }
        }

        public string FileUploadPath
        {
            get
            {
                return configuration["FileUploadPath"];
            }
        }

        public string FileDisplayPath
        {
            get
            {
                return configuration["FileDisplayPath"];
            }
        }

        public string APIToken
        {
            get
            {
                return configuration["APIToken"];
            }
        }

        public string NotificationAPIUrl
        {
            get
            {
                return configuration["NotificationAPIUrl"];
            }
        }

        public string MOM_AuthKey
        {
            get
            {
                return configuration["MOM_AuthKey"];
            }
        }

        public string MOM_TPIN
        {
            get
            {
                return configuration["MOM_TPIN"];
            }
        }

        public string MOM_UserCode
        {
            get
            {
                return configuration["MOM_UserCode"];
            }
        }

        public string PMT_AccessKey
        {
            get
            {
                return configuration["PMT_AccessKey"];
            }
        }

        public string PMT_AccessPwd
        {
            get
            {
                return configuration["PMT_AccessPwd"];
            }
        }
        public string Bank_API_Path
        {
            get
            {
                return configuration["Bank_API_Path"];
            }
        }
        public string PMT_API_Path
        {
            get
            {
                return configuration["PMT_API_Path"];
            }
        }
        public string PAN_Integration_Passkey
        {
            get
            {
                return configuration["PAN_Integration_Passkey"];
            }
        }

        public string PAN_Verification_Passkey
        {
            get
            {
                return configuration["PAN_Verification_Passkey"];
            }
        }

        public string PAN_Integration_URL
        {
            get
            {
                return configuration["PAN_Integration_URL"];
            }
        }
        public string CyberPlat_Seckey
        {
            get
            {
                return configuration["CyberPlat_Seckey"];
            }
        }

        public string CyberPlat_SDCODE
        {
            get
            {
                return configuration["CyberPlat_SDCODE"];
            }
        }

        public string CyberPlat_APCODE
        {
            get
            {
                return configuration["CyberPlat_APCODE"];
            }
        }

        public string HdFcAPIURL
        {
            get
            {
                return configuration["HdFcAPIURL"];
            }
        }
        public string CyberPlat_Key
        {
            get
            {
                return configuration["CyberPlat_Key"];
            }
        }

        private string GetParameterValue(string ParamName)
        {
            if (configuration[ParamName] != null)
                return configuration[ParamName];
            else
                return "";
        }
        public string FileDownloadPath
        {
            get
            {
                return configuration["FileDownloadPath"];
            }
        }
        public string CamsFilesPath
        {
            get
            {
                return configuration["CamsFilesPath"];
            }
        }
        public string FileStorageDirectory
        {
            get
            {
                return configuration["FileStorageDirectory"];
            }
        }

        public bool IsStorageLocal
        {
            get
            {
                return Convert.ToBoolean(configuration["IsStorageLocal"]);
            }
        }


        public string AzureFileUploadProtocol
        {
            get
            {
                return configuration["AzureFileUploadProtocol"];
            }
        }

        public string DashboardConnectionString
        {
            get
            {
                return configuration["DashboardConnectionString"];
            }
        }

        public string StorageConnectionString
        {
            get
            {
                return configuration["StorageConnectionString"];
            }
        }

        public string RedisCacheConnectionString
        {
            get
            {
                return configuration["RedisCacheConnectionString"];
            }
        }

        public string RedisCacheTimeoutMinutes
        {
            get
            {
                return configuration["RedisCacheTimeoutMinutes"];
            }
        }

        public string RedisCacheMaxTimeoutMinutes
        {
            get
            {
                return configuration["RedisCacheMaxTimeoutMinutes"];
            }
        }

        public string StickerImageWidth
        {
            get
            {
                return configuration["StickerImageWidth"];
            }
        }

        public string StickerImageHeight
        {
            get
            {
                return configuration["StickerImageHeight"];
            }
        }

        public string StickerImageExtension
        {
            get
            {
                return configuration["StickerImageExtension"];
            }
        }

        public string ThumbnailImageWidth
        {
            get
            {
                return configuration["ThumbnailImageWidth"];
            }
        }

        public string ThumbnailImageHeight
        {
            get
            {
                return configuration["ThumbnailImageHeight"];
            }
        }

        public string ThumbnailImageExtension
        {
            get
            {
                return configuration["ThumbnailImageExtension"];
            }
        }

        public string PreviewImageWidth
        {
            get
            {
                return configuration["PreviewImageWidth"];
            }
        }

        public string PreviewImageHeight
        {
            get
            {
                return configuration["PreviewImageHeight"];
            }
        }

        public string PreviewImageExtension
        {
            get
            {
                return configuration["PreviewImageExtension"];
            }
        }
        public string FIANetworkAzure
        {
            get
            {
                return configuration.GetConnectionString("FIADBAzure");
            }
        }
        public string CheckSumKeyMutual
        {
            get
            {
                return configuration["CheckSumKeyMutual"];
            }
        }
        public string CheckSumKeyB2B
        {
            get
            {
                return configuration["CheckSumKeyB2B"];
            }
        }
        public string CheckSumKeyB2C
        {
            get
            {
                return configuration["CheckSumKeyB2C"];
            }
        }
        public string CheckSumKeyOther
        {
            get
            {
                return configuration["CheckSumKeyOther"];
            }
        }
        public string IS_dbType
        {
            get
            {
                return configuration["IsDBType"];
            }
        }
        public string DigiLockerBaseURL
        {
            get
            {
                return configuration["DigilockerBaseURI"];
            }
        }
        public string DigiLockerClientID
        {
            get
            {
                return configuration["DigilockerClientID"];
            }
        }
        public string DigiLockerClientSecret
        {
            get
            {
                return configuration["DigilockerClientSecret"];
            }
        }
        public string DigiLockerRedirectURI
        {
            get
            {
                return configuration["DigilockerRedirectURI"];
            }
        }
        public string FIAPrivatekey
        {
            get
            {
                return configuration["FIAPrivatekey"];
            }
        }
        public string FIAPrivatekey_old
        {
            get
            {
                return configuration["FIAPrivatekey_old"];
            }
        }
        public string HDFCPassword
        {
            get
            {
                return configuration["HDFCPassword"];
            }
        }
        public string HDFCAPIKey
        {
            get
            {
                return configuration["HDFCAPIKey"];
            }
        }
        public string HDFCAPIDDPKey
        {
            get
            {
                return configuration["HDFCAPIDDPKey"];
            }
        }
        public string HDFCURL
        {
            get
            {
                return configuration["HDFCURL"];
            }
        }
        public string HDFCFDDScope
        {
            get
            {
                return configuration["HDFCFDDScope"];
            }
        }
        public string HDFCClientCode
        {
            get
            {
                return configuration["HDFCClientCode"];
            }
        }
        public string HDFCLeadSource
        {
            get
            {
                return configuration["LeadSource"];
            }
        }
        public string HdfcLeadSourceKey
        {
            get
            {
                return configuration["LeadSourceKey"];
            }
        }
        public string YBLiv
        {
            get
            {
                return configuration["YBLiv"];
            }
        }

        public string YBLISENCRYPTED
        {
            get
            {
                return configuration["YBLISENCRYPTED"];
            }
        }

        public string YBLAgentURL
        {
            get
            {
                return configuration["YBLAgentURL"];
            }
        }

        public string YBLCustomerURL
        {
            get
            {
                return configuration["YBLCustomerURL"];
            }
        }

        public string YBLCustomerPartnerId
        {
            get
            {
                return configuration["YBLCustomerPartnerId"];
            }
        }

        public string YBLCustomerPublicKey
        {
            get
            {
                return configuration["YBLCustomerPublicKey"];
            }
        }

        public string YBLCustomerPrivateKey
        {
            get
            {
                return configuration["YBLCustomerPrivateKey"];
            }
        }

        public string YBLDMTAgentnbfcStatus
        {
            get
            {
                return configuration["YBLDMTAgentnbfcStatus"];
            }
        }
        public string YBLkey
        {
            get
            {
                return configuration["YBLkey"];
            }
        }
        public string YBLpublickey
        {
            get
            {
                return configuration["YBLpublickey"];
            }
        }
        public string YBLPartnerKey
        {
            get
            {
                return configuration["YBLPartnerKey"];
            }
        }
        public string YBLfiaprivatekey
        {
            get
            {
                return configuration["YBLfiaprivatekey"];
            }
        }
        public string DigiGoldMMTCBaseUrl
        {
            get
            {
                return configuration["DigiGoldMMTCBaseUrl"];
            }
        }
        public string DigiGoldMMTCUserName
        {
            get
            {
                return configuration["DigiGoldMMTCUserName"];
            }
        }
        public string DigiGoldMMTCPassword
        {
            get
            {
                return configuration["DigiGoldMMTCPassword"];
            }
        }
        public string DigiGoldMMTCPartnerId
        {
            get
            {
                return configuration["DigiGoldMMTCPartnerId"];
            }
        }
        public string AirtelDMTBaseURL
        {
            get
            {
                return configuration["AirtelDMTBaseURL"];
            }
        }
        public string AirtelPartnerId
        {
            get
            {
                return configuration["AirtelPartnerId"];
            }
        }
        public string AirtelSalt
        {
            get
            {
                return configuration["AirtelSalt"];
            }
        }
        public string AirtelChanel
        {
            get
            {
                return configuration["AirtelChanel"];
            }
        }
        public string GIBLUMC
        {
            get
            {
                return configuration["GIBLUMC"];
            }
        }
        public string CMSCertificate
        {
            get
            {
                return configuration["CMSCertificate"];
            }
        }
        public string CMSMerchantId
        {
            get
            {
                return configuration["CMSMerchantId"];
            }
        }
        public string CMSMerchantLoginId
        {
            get
            {
                return configuration["CMSMerchantLoginId"];
            }
        }
        public string CMSMerchantPass
        {
            get
            {
                return configuration["CMSMerchantPass"];
            }
        }
        public string CMSpassword
        {
            get
            {
                return configuration["CMSpassword"];
            }
        }
        public string CMSAgreegator
        {
            get
            {
                return configuration["CMSAgreegator"];
            }
        }
        public string CMSAPIURL
        {
            get
            {
                return configuration["CMSAPIURL"];
            }
        }
        public string CMSMerchantSecurityKey
        {
            get
            {
                return configuration["CMSMerchantSecurityKey"];
            }
        }

        public string CMSsuperMerchantSkey
        {
            get
            {
                return configuration["CMSsuperMerchantSkey"];
            }
        }
        public string CMSSingleSignOnURL
        {
            get
            {
                return configuration["CMSSingleSignOnURL"];
            }
        }
        public string CMSAPIMerURL
        {
            get
            {
                return configuration["CMSAPIMerURL"];
            }
        }
        public string CMSAPIKYCURL
        {
            get
            {
                return configuration["CMSAPIKYCURL"];
            }
        }

        public string AirtelAEPSURL
        {
            get
            {
                return configuration["AirtelAEPSURL"];
            }
        }

        public string AirtelAEPSserviceId
        {
            get
            {
                return configuration["AirtelAEPSserviceId"];
            }
        }

        public string AirtelAEPSclientId
        {
            get
            {
                return configuration["AirtelAEPSclientId"];
            }
        }
        public string AirtelAEPSclientSecret
        {
            get
            {
                return configuration["AirtelAEPSclientSecret"];
            }
        }

        public string AirtelAEPSencryptionKey
        {
            get
            {
                return configuration["AirtelAEPSencryptionKey"];
            }
        }

        public string AirtelAEPSsalt
        {
            get
            {
                return configuration["AirtelAEPSsalt"];
            }
        }
    }
}
