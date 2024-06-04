using SANYUKT.Database;
using SANYUKT.Datamodel.Common;
using SANYUKT.Datamodel.Entities.Activity;
using SANYUKT.Datamodel.Interfaces;
using SANYUKT.Datamodel.Shared;
using SANYUKT.Repository.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Repository
{
    public class ActivityLogRepository : BaseRepository
    {
        private readonly ISANYUKTDatabase _database = null;

        public ActivityLogRepository()
        {
            _database = new SANYUKTDatabase();
        }

        public async Task<ListResponse> ActivityLog_Search(ActivityLogRequest request, ISANYUKTServiceUser FIAAPIUser)
        {
            ListResponse response = new ListResponse();
            List<ActivityLogResponse> lst = new List<ActivityLogResponse>();
            var dbCommand = _database.GetStoredProcCommand("[AAC].[ActivityLog_Search]");
            _database.AutoGenerateInputParams(dbCommand, request, FIAAPIUser, true);

            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    ActivityLogResponse row = new ActivityLogResponse();
                    row.FromReader(dataReader);
                    lst.Add(row);
                }
            }

            response.SetPagingOutput(dbCommand);
            response.CurrentPage = request.PageNo;
            response.Result = lst;

            return response;
        }

        public async Task<long> ActivityLog_Add(ActivityEnum ActivityID, long EntityID, ISANYUKTServiceUser FIAAPIUser, DateTimeOffset? ActivityDate, string Comments)
        {
            var dbCommand = _database.GetStoredProcCommand("[AAC].[ActivityLog_Add]");
            dbCommand.Parameters.AddWithValue("@ActivityID", ActivityID);
            dbCommand.Parameters.AddWithValue("@EntityID", EntityID);
            dbCommand.Parameters.AddWithValue("@ActivityDate", ActivityDate);
            dbCommand.Parameters.AddWithValue("@Comments", Comments);
            dbCommand.Parameters.AddWithValue("@LoggedInUserMasterID", FIAAPIUser.UserMasterID);
            _database.AddOutParameter(dbCommand, "@Out_ID", OUTPARAMETER_SIZE);
            await _database.ExecuteNonQueryAsync(dbCommand);

            return GetIDOutputLong(dbCommand);
        }
    }
}
