namespace DataAccessLibrary
{
    public interface IKeyVaultAccess
    {
        string ConnectionStringName { get; set; }

        string Decrypt(string data);
        string Encrypt(string data);
    }
}