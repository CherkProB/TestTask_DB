﻿using TestTask.DataBaseProviders.Base;
using TestTask.DataBaseProviders.MySQL;

namespace TestTask.Startup
{
    public class Program
    {
        private const string ConnectionString = "server=127.0.0.1;port=3306;username=root;password=;database=test_task";
        private const bool IsDetailed = false;

        private static void Main(string[] args)
        {
            BaseDBProvider baseDBProvider = new MySQLDBProvider(ConnectionString, IsDetailed);
            
        }
    }
}