using System.Text.Json;

namespace SchoolProject.Core.Helpers.BaseResponse
{
    public class BaseResponse<T>
    {

        public BaseResponse(bool isSucceeded, T data = default, string message = null, Dictionary<string, string[]> errors = null)
        {
            Succeeded = isSucceeded;
            Message = message;
            Errors = errors;
            Data = data;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }

        public T Data { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
