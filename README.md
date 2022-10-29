# Clothing-App-Xamarin

Bước 1: Tạo ra một file tên là EnvironmentVariable.cs nằm trong folder ClothingApp và cấu hình code bên trong như sau

using System;
using System.Collections.Generic;
using System.Text;

namespace ClothingApp
{
    public class EnvironmentVariable
    {
        public string srvrdbname {
            get
            {
                return "" // database name;
            }
        }
        public string srvrname {
            get
            {
                return "" // Your IPV4 address;
            }
        }
        public string srvrusername
        {
            get
            {
                return "" // Your username of SQL Server;
            }
        }
        public string srvrpassword
        {
            get
            {
                return "" // Your password of SQL Server;
            }
        }
    }
}
