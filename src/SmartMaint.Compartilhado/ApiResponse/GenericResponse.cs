namespace SmartMaint.Compartilhado.ApiResponse
{
    public class GenericResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public object Data { get; set; }

        public GenericResponse(bool success, object data, string message = null, List<string> errors = null)
        {
            Success = success;
            Message = message ?? string.Empty;
            Errors = errors ?? [];
            Data = data;
        }

        public static GenericResponse SuccessResponse(object data, string message = null)
        {
            return new GenericResponse(true, data, message);
        }

        public static GenericResponse ErrorResponse(string message = null, List<string> errors = null, object data = null)
        {
            return new GenericResponse(false, data, message, errors);
        }

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}
