using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp.Helpers
{
    public class ApiResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public ApiResponse()
        {
            this.success = false;
            this.message = "";
            this.data = null;
        }

        public ApiResponse(bool success, object Data)
        {
            this.success = success;
            this.data = Data;
        }

        public ApiResponse(bool success, string message)
        {
            this.success = success;
            this.message = message;
        }

        public ApiResponse(bool success, object data, string message)
        { 
            this.success = success;
            this.data = data;
            this.message = message;
        }
    }
}
