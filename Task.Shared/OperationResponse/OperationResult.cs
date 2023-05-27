using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Task.Shared.API;

namespace Task.Shared.OperationResponse
{
    public  class OperationResult<T>
    {
        public OperationOutputStatus Status { get; set; }

        public T Data { get; set; }

        [JsonConverter(typeof(ConfigConverter<IErrorCodes, CommonErrorCodes>))]
        public IErrorCodes Code { get; set; }

        public HttpErrorCode HttpErrorCode { get; set; }

        public string ErrorMessage { get; set; }
        public bool IsSucceeded => Status == OperationOutputStatus.Success;

        public long? LogRefNo { get; set; }
        public static OperationResult<T> Success(T result)
        {
            return new OperationResult<T>
            {
                Code = CommonErrorCodes.NULL,
                Data = result,
                Status = OperationOutputStatus.Success
            };
        }

        public static OperationResult<T> Fail(IErrorCodes errorCode, string description = "")
        {
            return new OperationResult<T>
            {
                Code = errorCode,
                HttpErrorCode = HttpErrorCode.InvalidInput,
                ErrorMessage = description,
                Status = OperationOutputStatus.Fail
            };
        }
        public static OperationResult<T> Fail(HttpErrorCode httpErrorCode, IErrorCodes errorCode, string description = "")
        {
            return new OperationResult<T>
            {
                Code = errorCode,
                HttpErrorCode = httpErrorCode,
                ErrorMessage = description,
                Status = OperationOutputStatus.Fail
            };
        }
        public static OperationResult<T> Fail(HttpErrorCode httpErrorCode, string description = "")
        {
            return new OperationResult<T>
            {
                Code = CommonErrorCodes.NULL,
                HttpErrorCode = httpErrorCode,
                ErrorMessage = description,
                Status = OperationOutputStatus.Fail,
            };
        }

        public static OperationResult<T> Fail(HttpErrorCode httpErrorCode, IErrorCodes errorCode, long? logRefNo)
        {
            return new OperationResult<T>
            {
                Code = errorCode,
                HttpErrorCode = httpErrorCode,
                ErrorMessage = $"See Log File {logRefNo}",
                Status = OperationOutputStatus.Fail,
                LogRefNo = logRefNo
            };
        }

        public static OperationResult<T> Fail(string description)
        {
            return new OperationResult<T>
            {
                Code = CommonErrorCodes.INVALID_INPUT,
                HttpErrorCode = HttpErrorCode.InvalidInput,
                ErrorMessage = description,
                Status = OperationOutputStatus.Fail
            };
        }

        public static OperationResult<T> ServerError(IErrorCodes errorCode, string description = "")
        {
            return new OperationResult<T>
            {
                Code = errorCode,
                ErrorMessage = description,
                Status = OperationOutputStatus.ServerError
            };
        }

        public static OperationResult<T> ServerError(Exception ex, string error = null)
        {
            return new OperationResult<T>
            {
                Code = CommonErrorCodes.SERVER_ERROR,
                HttpErrorCode = HttpErrorCode.ServerError,
                ErrorMessage = error ?? ex.Message,
                Status = OperationOutputStatus.ServerError
            };
        }
    }
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum OperationOutputStatus
    {
        Success,
        Fail,
        ServerError
    }

    // ReSharper disable once InconsistentNaming
    public class ConfigConverter<I, T> : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(I);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new InvalidOperationException("Use default serialization.");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var deserialized = (T)Activator.CreateInstance(typeof(T));
            serializer.Populate(jsonObject.CreateReader(), deserialized);
            return deserialized;
        }
    }
}
