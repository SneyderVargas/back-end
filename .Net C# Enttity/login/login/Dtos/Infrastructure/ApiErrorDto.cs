using login.Resx;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.ComponentModel;

namespace login.Dtos.Infrastructure
{
    public class ApiErrorDto
    {
        public string Message { get; set; }

        public string Detail { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue("")]
        public string StackTrace { get; set; }
        public ApiErrorDto()
        {
        }

        public ApiErrorDto(string message)
        {
            Message = message;
        }

        public ApiErrorDto(ModelStateDictionary modelState)
        {
            Message = InfrastructureMsg.ApiErrorInvalidParams;
            Detail = modelState
              .FirstOrDefault(x => x.Value.Errors.Any()).Value.Errors
              .FirstOrDefault().ErrorMessage;
        }
    }
}
