using SANYUKT.Datamodel.Common;


namespace SANYUKT.Datamodel.Interfaces
{
    public interface ISANYUKTServiceUser
    {
        string UserToken { get; set; }
        string ApiToken { get; set; }
        Int64? UserMasterID { get; set; }
        Int32? OrganizationID { get; set; }
        Int32? WorkOrganizationID { get; set; }
        string ApplicationName { get; set; }
        int ApplicationID { get; set; }
        string IPAddress { get; set; }
        string RequestUrl { get; set; }
        string ReferrerUrl { get; set; }
        string Headers { get; set; }
        string ClientIPAddress { get; set; }
        ApplicationTypes AppType { get; set; }


    }
}
