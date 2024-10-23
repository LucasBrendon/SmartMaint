namespace SmartMaint.Aplicacao.Aplicacao.Base
{
    public class ApiResponse    
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public List<string> Errors { get; set; }

        public ApiResponse()
        {
            Errors = new List<string>();
        }

        public ApiResponse(object data, string message = null)
        {
            Success = true;
            Message = message ?? "Operação bem-sucedida.";
            Data = data;
            Errors = new List<string>();
        }

        public ApiResponse(string error, string message = null)
        {
            Success = false;
            Message = message ?? "Erro ao processar operação.";
            Errors = new List<string> { error };
        }
    }
}
