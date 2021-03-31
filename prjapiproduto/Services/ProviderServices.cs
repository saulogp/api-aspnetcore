using System.Collections.Generic;
using MongoDB.Driver;
using prjapiproduto.Models;
using prjapiproduto.Utils;

namespace prjapiproduto.Services
{
    public class ProviderServices
    {
        private readonly IMongoCollection<Provider> _providers;

        public ProviderServices(IProjMongoDotnetDatabaseSettings settings)
        {
            var product = new MongoClient(settings.ConnectionString);
            var database = product.GetDatabase(settings.DatabaseName);
            _providers = database.GetCollection<Provider>(settings.ProductCollectionName);
        }

        public List<Provider> Get() => _providers.Find(fornecedor => true).ToList();

        public Provider Get(string id) => _providers.Find<Provider>(fornecedor => fornecedor.Id == id).FirstOrDefault();

        public Provider Create(Provider fornecedor)
        {
            _providers.InsertOne(fornecedor);
            return fornecedor;
        }
        public void Update(string id, Provider fornecedorIn) => _providers.ReplaceOne(fornecedor => fornecedor.Id == id, fornecedorIn);

        public void Remove(Provider fornecedorIn) => _providers.DeleteOne(fornecedor => fornecedor.Id == fornecedorIn.Id);

        public void Remove(string id) => _providers.DeleteOne(fornecedor => fornecedor.Id == id);  
    }
}