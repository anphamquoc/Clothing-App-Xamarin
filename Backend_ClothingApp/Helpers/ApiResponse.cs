using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Helpers
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ApiResponse(bool success, object Data)
        {
            this.Success = success;
            this.Data = Data;
        }

        public ApiResponse(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }
    }
}
