namespace prjapiproduto.Utils
{
    public interface IProjMongoDotnetDatabaseSettings
    {
         string ProductCollectionName { get; set; }
         string ConnectionString { get; set; }
         string DatabaseName { get; set; }
    }
}