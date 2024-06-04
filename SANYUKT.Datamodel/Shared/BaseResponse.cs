using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SANYUKT.Datamodel.Shared
{
    public class BaseResponse
    {
        public bool HasError
        {
            get
            {
                if (Errors == null)
                    return false;
                if (Errors.Count == 0)
                    return false;
                else
                    return true;
            }
        }

        public List<ErrorResponse> Errors { get; set; }

        public void SetError(ErrorResponse error)
        {
            if (Errors == null)
                Errors = new List<ErrorResponse>();
            Errors.Add(error);
        }

        public void SetError(List<ValidationResult> ValidationErrors)
        {
            if (Errors == null)
                Errors = new List<ErrorResponse>();
            foreach (var item in ValidationErrors)
            {
                Errors.Add(new ErrorResponse(ErrorCodes.VALIDATION_ERROR, item.ErrorMessage));
            }
        }


        public void SetError(ErrorCodes errorCode)
        {
            if (Errors == null)
                Errors = new List<ErrorResponse>();
            ErrorResponse error = new ErrorResponse();
            //error.SetError(errorCode);
            Errors.Add(error);
        }

        public void SetError(ErrorCodes errorCode, string Message)
        {
            if (Errors == null)
                Errors = new List<ErrorResponse>();
            ErrorResponse error = new ErrorResponse(errorCode, Message);
            Errors.Add(error);
        }

        public void SetError(List<ErrorResponse> errors)
        {
            Errors = errors;
        }

        public string GetErrorMessage()
        {
            StringBuilder errorMessage = new StringBuilder();
            if (HasError)
            {
                foreach (ErrorResponse error in Errors)
                {
                    errorMessage.AppendLine(error.ErrorMessage);
                }
            }
            return errorMessage.ToString();
        }

        public void SetError(string ErrorMessage)
        {
            if (Errors == null)
                Errors = new List<ErrorResponse>();

            ErrorResponse error = new ErrorResponse(ErrorMessage);

            Errors.Add(error);
        }


        public void FromModelState(ModelStateDictionary ModelState)
        {
            if (ModelState.IsValid)
                return;

            foreach (string modelKey in ModelState.Keys)
            {
                ModelStateEntry row = ModelState[modelKey];

                foreach (ModelError err in row.Errors)
                {
                    this.Errors.Add(new ErrorResponse() { ErrorMessage = err.ErrorMessage, ErrorCode = ErrorCodes.VALIDATION_ERROR });
                }
            }
        }

        public void ToModelState(ModelStateDictionary ModelState)
        {
            for (int index = 0; index < Errors.Count; index++)
            {
                ModelState.AddModelError(index.ToString(), Errors[index].ErrorMessage);
            }
        }
    }
}
