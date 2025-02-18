﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace DataAccessLibrary
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "AZURE_SQL_CONNECTIONSTRING";

        public SQLDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task<T> SaveDataReturn<T>(string storedProc, object parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName)
                ?? throw new Exception("Missing connection string at " + ConnectionStringName);

            using var connection = new SqlConnection(connectionString);

            var data = await connection.QuerySingleAsync<T>(storedProc, parameters, commandType: System.Data.CommandType.StoredProcedure);

            return data;

        }


        public async Task SaveData(string storedProc, object parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName)
                ?? throw new Exception("Missing connection string at " + ConnectionStringName);

            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(storedProc, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<List<T>> LoadData<T>(string storedProc, object parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName)
                ?? throw new Exception("Missing connection string at " + ConnectionStringName);

            using var connection = new SqlConnection(connectionString);

            var res = await connection.QueryAsync<T>(storedProc, parameters, commandType: System.Data.CommandType.StoredProcedure);

            return res.ToList();
        }

        public async Task<T> LoadDataSingle<T>(string storedProc, object parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName)
                ?? throw new Exception("Missing connection string at " + ConnectionStringName);

            using var connection = new SqlConnection(connectionString);

            var res = await connection.QuerySingleAsync<T>(storedProc, parameters, commandType: System.Data.CommandType.StoredProcedure);

            return res;
        }

    }
}
