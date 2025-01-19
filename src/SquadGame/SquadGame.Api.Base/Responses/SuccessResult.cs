using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SquadGame.Api.Base.Responses
{
    public class SuccessResult<TData> : JsonResult
    {
        public SuccessResult() : base(new { data = default(TData), ok = true })
        {
            Data = default;
            Ok = true;
            StatusCode = StatusCodes.Status200OK;
        }

        public SuccessResult(TData value) : base(new { data = value, ok = true })
        {
            Data = value;
            Ok = true;
            StatusCode = StatusCodes.Status200OK;
        }

        public SuccessResult(TData value, JsonSerializerSettings serializerSettings) : base(
            new { data = value, ok = true }, serializerSettings)
        {
            Data = value;
            Ok = true;
            StatusCode = StatusCodes.Status200OK;
        }

        [System.Text.Json.Serialization.JsonIgnore] public new string ContentType { get; set; }

        [System.Text.Json.Serialization.JsonIgnore] public new int? StatusCode { get; set; }

        [JsonProperty("data")] public TData? Data { get; set; }

        [JsonProperty("ok")] public bool Ok { get; set; }
    }

    public class SuccessResult : JsonResult
    {
        public SuccessResult() : base(new { data = default(object), ok = true })
        {
            Data = default;
            Ok = true;
            StatusCode = StatusCodes.Status200OK;
        }

        public SuccessResult(object value) : base(new { data = value, ok = true })
        {
            Data = value;
            Ok = true;
            StatusCode = StatusCodes.Status200OK;
        }

        public SuccessResult(object value, JsonSerializerSettings serializerSettings) : base(
            new { data = value, ok = true }, serializerSettings)
        {
            Data = value;
            Ok = true;
            StatusCode = StatusCodes.Status200OK;
        }

        [JsonProperty("data")] public object? Data { get; set; }

        [JsonProperty("ok")] public bool Ok { get; set; }

        [System.Text.Json.Serialization.JsonIgnore] public new int? StatusCode { get; set; }

        [System.Text.Json.Serialization.JsonIgnore] public new string ContentType { get; set; }
    }
}
