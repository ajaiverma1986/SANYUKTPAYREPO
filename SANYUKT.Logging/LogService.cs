using SANYUKT.Datamodel.Interfaces;
using SANYUKT.Datamodel.Shared;
using System.Text;
using Newtonsoft.Json;
using NLog.Config;
using SANYUKT.Configuration;


namespace SANYUKT.Logging
{
    public class LoggingService : ILoggingService
    {
        public static NLog.Logger logger;
        private static bool _LogInitDone = false;

        public LoggingService()
        {
            InitializeConfigurations();
        }

        public static LoggingService GetLogger()
        {
            return new LoggingService();
        }

        public async Task LogMessage(Log log, object loggerClass, object moreInfo = null)
        {
            await Log(log, NLog.LogLevel.Info, loggerClass, moreInfo);
        }

        public async Task LogMessage(string message, ISANYUKTServiceUser serviceUser, object moreInfo = null)
        {
            await LogMessage(message, serviceUser, string.Empty, string.Empty, moreInfo);
        }

        public async Task LogMessage(string message, ISANYUKTServiceUser serviceUser, string moduleName, string title, object moreInfo = null)
        {
            Log log = new Log();
            log.Message = message;
            log.ModuleName = moduleName;
            log.Title = title;
            await InitializeLog(serviceUser, log);
            await Log(log, NLog.LogLevel.Info, serviceUser, moreInfo);
        }

        public async Task LogWarning(List<ErrorResponse> errors, Log log, object loggerClass, object moreInfo = null)
        {
            await InitializeWarningLog(errors, log);
            await Log(log, NLog.LogLevel.Warn, loggerClass, moreInfo);
        }

        public async Task LogWarning(List<ErrorResponse> errors, ISANYUKTServiceUser serviceUser, object moreInfo = null)
        {
            await LogWarning(errors, serviceUser, string.Empty, string.Empty, moreInfo);
        }

        public async Task LogWarning(List<ErrorResponse> errors, ISANYUKTServiceUser serviceUser, string moduleName, string title, object moreInfo = null)
        {
            Log log = new Log();
            await InitializeLog(serviceUser, log);
            await InitializeWarningLog(errors, log);
            await Log(log, NLog.LogLevel.Warn, serviceUser, moreInfo);
        }

        public async Task LogWarning(ErrorResponse error, ISANYUKTServiceUser serviceUser, object moreInfo = null)
        {
            await LogWarning(error, serviceUser, string.Empty, string.Empty, moreInfo);
        }

        public async Task LogWarning(ErrorResponse error, ISANYUKTServiceUser serviceUser, string moduleName, string title, object moreInfo = null)
        {
            List<ErrorResponse> errors = new List<ErrorResponse>();
            errors.Add(error);
            Log log = new Log();
            await InitializeLog(serviceUser, log);
            await InitializeWarningLog(errors, log);
            await Log(log, NLog.LogLevel.Warn, serviceUser, moreInfo);
        }


        public async Task LogError(Exception exception, Log log, object moreInfo = null)
        {
            await InitializeErrorLog(exception, log);
            await Log(log, NLog.LogLevel.Error, null, moreInfo);
        }

        public async Task LogError(Exception exception, Log log, object loggerClass, object moreInfo = null)
        {
            await InitializeErrorLog(exception, log);
            await Log(log, NLog.LogLevel.Error, loggerClass, moreInfo);
        }

        public async Task LogError(Exception exception, object loggerClass, object moreInfo = null)
        {
            await LogError(exception, loggerClass, string.Empty, string.Empty, moreInfo);
        }

        public async Task LogError(Exception exception, object loggerClass, ISANYUKTServiceUser serviceUser, object moreInfo = null)
        {
            Log log = new Log();
            await InitializeLog(serviceUser, log);
            await InitializeErrorLog(exception, log);
            await Log(log, NLog.LogLevel.Error, loggerClass, moreInfo);
        }

        public async Task LogError(Exception exception, object loggerClass, string moduleName, string title, object moreInfo = null)
        {
            Log log = new Log();
            log.ModuleName = moduleName;
            log.Title = title;
            await InitializeErrorLog(exception, log);
            await Log(log, NLog.LogLevel.Error, loggerClass, moreInfo);
        }

        private async Task Log(Log log, NLog.LogLevel logLevel, object loggerClass, object moreInfo = null)
        {
            InitializeConfigurations();

            NLog.LogEventInfo logEvent = new NLog.LogEventInfo(logLevel, "NLOG", log.Message);
            logEvent.Properties["title"] = log.Title;
            logEvent.Properties["message"] = log.Message;
            logEvent.Properties["modulename"] = log.ModuleName;
            logEvent.Properties["apitoken"] = log.ApiToken;
            logEvent.Properties["usertoken"] = log.UserToken;
            logEvent.Properties["UserMasterID"] = log.UserMasterID;
            logEvent.Properties["applicationname"] = log.ApplicationName;
            logEvent.Properties["applicationid"] = log.ApplicationId;
            logEvent.Properties["ipaddress"] = log.IpAddress;
            logEvent.Properties["url"] = log.Url;
            logEvent.Properties["referrerurl"] = log.ReferrerUrl;
            logEvent.Properties["headers"] = log.Headers;
            logEvent.Properties["stacktrace"] = log.StackTrace;
            logEvent.Properties["innerexception"] = log.InnerException;

            if (moreInfo != null)
                logEvent.Properties["moreinfo"] = JsonConvert.SerializeObject(moreInfo);
            else
                logEvent.Properties["moreinfo"] = log.MoreInfo;

            logger.Log(logEvent);
        }

        private async Task InitializeLog(ISANYUKTServiceUser serviceUser, Log log)
        {
            if (serviceUser != null)
            {
                log.ApiToken = serviceUser.ApiToken;
                log.UserToken = serviceUser.UserToken;
                log.UserMasterID = serviceUser.UserMasterID;
                log.ApplicationName = serviceUser.ApplicationName;
                log.ApplicationId = serviceUser.ApplicationID;

                if (!string.IsNullOrEmpty(serviceUser.ClientIPAddress))
                    log.IpAddress = serviceUser.ClientIPAddress;
                else
                    log.IpAddress = serviceUser.IPAddress;

                log.Url = serviceUser.RequestUrl;
                log.ReferrerUrl = serviceUser.ReferrerUrl;
                log.Headers = serviceUser.Headers;
                //log.MoreInfo = serviceUser.MoreInfo;
            }
        }

        private async Task InitializeWarningLog(List<ErrorResponse> errors, Log log)
        {
            StringBuilder errorMessage = new StringBuilder();
            foreach (var error in errors)
            {
                errorMessage.AppendLine(string.Format("{0}:{1}", error.ErrorCode.ToString(), error.ErrorMessage));
            }
            log.Message = errorMessage.ToString();
        }

        private async Task InitializeErrorLog(Exception exception, Log log)
        {
            log.Message = exception.Message;
            if (exception.InnerException != null)
                log.InnerException = exception.InnerException.ToString();
            log.StackTrace = exception.StackTrace;
        }

        private static void InitializeConfigurations()
        {
            if (_LogInitDone)
                return;

            try
            {
                NLog.LogManager.Configuration = new XmlLoggingConfiguration("nlog.config");

                //Get the logging connection string from app settings
                NLog.Targets.DatabaseTarget dbTarget = (NLog.Targets.DatabaseTarget)NLog.LogManager.Configuration.FindTargetByName("db");
                if (dbTarget != null)
                    dbTarget.ConnectionString = SANYUKTApplicationConfiguration.Instance.LoggingDB;

                NLog.LogManager.Configuration.Reload();
                logger = NLog.LogManager.GetLogger("NLOG");
                _LogInitDone = true;
            }
            catch (Exception e)
            {
                //throw e;
            }
        }

    }
}
