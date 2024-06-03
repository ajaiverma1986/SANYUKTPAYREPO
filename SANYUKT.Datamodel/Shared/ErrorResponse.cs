

namespace SANYUKT.Datamodel.Shared
{
    public class ErrorResponse
    {
        private const string RESOURCE_MESSAGE_KEY_PREFIX = "CODE_";

        public ErrorCodes ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorResponse()
        {
            NoError();
        }

        //public ErrorResponse(ErrorCodes errorCode)
        //{
        //    ErrorCode = errorCode;
        //    string messageKey = RESOURCE_MESSAGE_KEY_PREFIX + errorCode.ToString("D");
        //    ErrorMessage = ErrorMessages.ResourceManager.GetString(messageKey);
        //}

        public ErrorResponse(ErrorCodes errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public ErrorResponse(string errorMessage)
        {
            ErrorCode = ErrorCodes.VALIDATION_ERROR;
            ErrorMessage = errorMessage;
        }

        public void NoError()
        {
            ErrorCode = ErrorCodes.NO_ERROR;
            ErrorMessage = string.Empty;
        }

        public static ErrorResponse GetNoError()
        {
            return new ErrorResponse(ErrorCodes.NO_ERROR, string.Empty);
        }

        //public void SetError(ErrorCodes ErrorCode)
        //{
        //    this.ErrorCode = ErrorCode;
        //    string messageKey = RESOURCE_MESSAGE_KEY_PREFIX + ErrorCode.ToString("D");
        //    ErrorMessage = ErrorMessages.ResourceManager.GetString(messageKey);
        //}

        public void SetError(ErrorResponse err)
        {
            this.ErrorCode = err.ErrorCode;
            this.ErrorMessage = err.ErrorMessage;
        }

        public void SetError(string ErrorMessage)
        {
            this.ErrorCode = ErrorCodes.SERVER_ERROR;
            this.ErrorMessage = ErrorMessage;
        }

        //public static ErrorResponse ForError(ErrorCodes ErrorCode)
        //{
        //    return new ErrorResponse(ErrorCode);
        //}

        public bool HasError
        {
            get
            {
                if (ErrorCode == ErrorCodes.NO_ERROR)
                    return false;
                else
                    return true;
            }
        }
    }
}
