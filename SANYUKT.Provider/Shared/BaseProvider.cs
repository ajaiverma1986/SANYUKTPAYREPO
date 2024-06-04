using SANYUKT.Datamodel.Interfaces;
using SANYUKT.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using SANYUKT.Datamodel.Common;

namespace SANYUKT.Provider.Shared
{
    /// <summary>
    /// Base Provider class contains all shared methods and properties
    /// </summary>
    public class BaseProvider
    {
        private readonly static ActivityLogRepository _activityRepository = new ActivityLogRepository();
        /// <summary>
        /// Logging Activities for Each entity action
        /// </summary>
        /// <param name="ActivityID"></param>
        /// <param name="EntityTypeID"></param>
        /// <param name="EntityID"></param>
        /// <param name="SANYUKTAPIUser"></param>
        /// <param name="Comments"></param>
        /// <returns>ActivityID</returns>
        public async static Task<long> ActivityLog(ActivityEnum ActivityID, long EntityID, ISANYUKTServiceUser SANYUKTAPIUser, DateTimeOffset? ActivityDate = null, string Comments = null)
        {
            long _activityID = await _activityRepository.ActivityLog_Add(ActivityID, EntityID, SANYUKTAPIUser, ActivityDate, Comments);

            if (_activityID <= 0)
            {
                await Logging.LoggingService.GetLogger().LogMessage($"Error while Activity Logging - {ActivityID}, Entity ID - {EntityID.ToString()}, Comments - {Comments}", SANYUKTAPIUser);
            }
            return _activityID;
        }

        public static bool Validate(out List<ValidationResult> validationResults, object request)
        {
            var context = new ValidationContext(request, serviceProvider: null, items: null);
            validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(request, context, validationResults, true);

            return isValid;
        }

    }
}
