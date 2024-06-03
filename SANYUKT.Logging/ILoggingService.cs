using SANYUKT.Datamodel.Interfaces;


namespace SANYUKT.Logging
{
    public interface ILoggingService
    {
        Task LogError(Exception exception, Log log, object moreInfo = null);
        Task LogError(Exception exception, object loggerClass, object moreInfo = null);
        Task LogError(Exception exception, Log log, object loggerClass, object moreInfo = null);
        Task LogError(Exception exception, object loggerClass, ISANYUKTServiceUser serviceUser, object moreInfo = null);
        Task LogError(Exception exception, object loggerClass, string moduleName, string title, object moreInfo = null);
        Task LogMessage(string message, ISANYUKTServiceUser serviceUser, object moreInfo = null);
        Task LogMessage(Log log, object loggerClass, object moreInfo = null);
        Task LogMessage(string message, ISANYUKTServiceUser spineUser, string moduleName, string title, object moreInfo = null);
    }
}
