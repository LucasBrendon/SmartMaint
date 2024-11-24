using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMaint.Compartilhado.ApiResponse
{
    public class ErrorDetail
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string ExceptionType { get; set; }
    }
}
