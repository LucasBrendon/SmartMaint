namespace SmartMaint.Api.Configuration
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public object Data { get; set; }

        public ApiResponse(bool success, object data, string message = null, List<string> errors = null)
        {
            Success = success;
            Message = message ?? string.Empty;
            Errors = errors ?? [];
            Data = data;
        }

        public static ApiResponse SuccessResponse(object data, string message = null)
        {
            return new ApiResponse(true, data, message);
        }

        public static ApiResponse ErrorResponse(string message = null, List<string> errors = null)
        {
            return new ApiResponse(false, default, message, errors);
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}
