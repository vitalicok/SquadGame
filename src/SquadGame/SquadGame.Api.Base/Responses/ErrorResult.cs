using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SquadGame.Api.Base.Exceptions;

namespace SquadGame.Api.Base.Responses
{
    public class ErrorResult : JsonResult
    {
        public ErrorResult(ExceptionBase exception) : base(new
        {   message = exception.Message, extraData = exception.ExtraData, ok = false })
        {
            Ok = false;
            Message = exception.Message;
            ExtraData = exception.ExtraData;
        }

        public ErrorResult(ExceptionBase exception, JsonSerializerSettings serializerSettings) : base(
            new { message = exception.Message, extraData = exception.ExtraData, ok = false },
            serializerSettings)
        {
            Ok = false;
            Message = exception.Message;
            ExtraData = exception.ExtraData;
        }

        public ErrorResult(string errorCode, string message, object? extraData = null) : base(new
        {   message, extraData, ok = false })
        {
            Ok = false;
            Message = message;
            ExtraData = extraData;
        }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("extraData")]
        public object? ExtraData { get; set; }

        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public new int? StatusCode { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public new string ContentType { get; set; }
    }
}
