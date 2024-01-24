﻿
namespace DataAccessLibrary
{
    public interface ISQLDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
        Task SaveData(string storedProc, string connectionName, object parameters);
    }
}