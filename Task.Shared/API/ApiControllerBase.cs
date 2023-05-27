using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Task.Shared.OperationResponse;

namespace Task.Shared.API
{
    //[Authorize]
    public class ApiControllerBase : ControllerBase
    {
        protected ActionResult ProcessResponse(HttpErrorCode errorCode, string erroMessage = "")
        {
            return StatusCode((int) errorCode, new { code = CommonErrorCodes.NULL.Value, erroMessage });
        }
        protected ActionResult ProcessResponse(ModelStateDictionary modelState)
        {

           var validationErrors = modelState.ToDictionary(
                            entry => entry.Key,
                            entry => entry.Value.Errors
                           .Where(error => !string.IsNullOrEmpty(error.ErrorMessage) || error.Exception != null)
                           .Select(error => !string.IsNullOrEmpty(error.ErrorMessage) ? error.ErrorMessage : error.Exception.Message).ToArray())
                           .Where(entry => entry.Value.Any())
                           .ToDictionary(entry => entry.Key, entry => entry.Value);

            var validationErrorsMessage = string.Empty;
            var isBeforeExist = false;
            foreach (var (key, value) in validationErrors)
            {
                if (isBeforeExist)
                {
                    validationErrorsMessage += " & ";
                }
                validationErrorsMessage += $"[{key}]:{string.Join(",", value)}";
                isBeforeExist = true;
            }
            return StatusCode((int)HttpErrorCode.InvalidInput, new { Code = CommonErrorCodes.INVALID_INPUT.Value, ErrorMessage= validationErrorsMessage });
        }
        protected ActionResult ProcessResponse<T>(OperationResult<T> response)
        {
            return response.IsSucceeded ? Ok(response.Data) : StatusCode((int)response.HttpErrorCode, new { code = response.Code.Code ,value = response.Code.Value , response.ErrorMessage });
        }
        protected ActionResult ProcessResponse<T>(PagedResponse<T> response)
        {
            return response.IsSucceeded ? Ok(response) : StatusCode((int)response.HttpErrorCode, new { code = response.Code.Code, value = response.Code.Value, response.ErrorMessage });
        }
    }
}
