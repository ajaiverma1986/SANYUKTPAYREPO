using SANYUKT.Datamodel.Common;
using SANYUKT.Datamodel.Library;
using System.Data.SqlClient;


namespace SANYUKT.Datamodel.Entities.Activity
{
    public class ActivityLogResponse
    {
        public long? EntityID { get; set; }


        public long? ActivityID { get; set; }


        public string Comments { get; set; }

        public DateTimeOffset? ActivityDate { get; set; }

        [SQLParam(Usage = SQLParamPlaces.None)]
        public string EntityType { get; set; }

        [SQLParam(Usage = SQLParamPlaces.None)]
        public string ActivityName { get; set; }

        [SQLParam(Usage = SQLParamPlaces.None)]
        public DateTimeOffset? CreatedOn { get; set; }

        [SQLParam(Usage = SQLParamPlaces.None)]
        public string CreatedBy { get; set; }
        public void FromReader(SqlDataReader reader)
        {
            ActivityID = DataReaderHelper.Instance.GetDataReaderValue_Long(reader, "ActivityID");
            EntityID = DataReaderHelper.Instance.GetDataReaderValue_Long(reader, "EntityID");
            ActivityName = DataReaderHelper.Instance.GetDataReaderValue_String(reader, "ActivityName");
            ActivityDate = DataReaderHelper.Instance.GetNullDataReaderValue_DateTimeOffset(reader, "ActivityDate");
            CreatedOn = DataReaderHelper.Instance.GetNullDataReaderValue_DateTimeOffset(reader, "CreatedOn");
            Comments = DataReaderHelper.Instance.GetDataReaderValue_String(reader, "Comments");
            CreatedBy = DataReaderHelper.Instance.GetDataReaderValue_String(reader, "CreatedBy");
        }
    }
}
