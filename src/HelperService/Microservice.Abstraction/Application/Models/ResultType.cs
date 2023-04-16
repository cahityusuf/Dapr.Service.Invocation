using System.Text.Json.Serialization;

namespace Microservice.Abstraction.Application.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ResultType
    {
        Ok,
        BadRequest,
        Unexpected,
        NotFound,
        Unauthorized,
        Invalid,
        NoContent,
        InvalidModel
    }
}
