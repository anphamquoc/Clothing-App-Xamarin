﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ClothingApp;

namespace ClothingApp.Model
{
    public class Connect
    {
        private string GetConnectionString()
        {
            //EnvironmentVariable environmentVariable = new EnvironmentVariable();
            //string srvrdbname = environmentVariable.srvrdbname; // your database name
            //string srvrname = environmentVariable.srvrname; // your IPV4 address
            //string srvrusername = environmentVariable.srvrusername; // your username of SQL Server
            //string srvrpassword = environmentVariable.srvrpassword; // your password of SQL Server
            //string sqlconn = $"Data Source={srvrname};Initial Catalog={srvrdbname};User ID={srvrusername};Password={srvrpassword}";
            //return sqlconn;
            return "aaa";
        }
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(GetConnectionString());
            }
        }
    }
}
