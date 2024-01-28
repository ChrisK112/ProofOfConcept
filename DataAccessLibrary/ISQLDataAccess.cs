
namespace DataAccessLibrary
{
    public interface ISQLDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task<List<T>> LoadData<T>(string storedProc, object parameters);
        Task<T> LoadDataSingle<T>(string storedProc, object parameters);
        Task SaveData(string storedProc, object parameters);
        Task SaveData<T>(string sql, T parameters);
        Task<T> SaveDataReturn<T>(string storedProc, object parameters);
    }
}