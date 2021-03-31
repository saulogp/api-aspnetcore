using System.Collections.Generic;
using MongoDB.Driver;
using prjapiproduto.Models;
using prjapiproduto.Utils;

namespace prjapiproduto.Services
{
    public class ProductServices
    {
        private readonly IMongoCollection<Product> _products;

        public ProductServices(IProjMongoDotnetDatabaseSettings settings)
        {
            var product = new MongoClient(settings.ConnectionString);
            var database = product.GetDatabase(settings.DatabaseName);
            _products = database.GetCollection<Product>(settings.ProductCollectionName);
        }

        public List<Product> Get() => _products.Find(produto => true).ToList();

        public Product Get(string id) => _products.Find<Product>(produto => produto.Id == id).FirstOrDefault();

        public Product Create(Product produto)
        {
            _products.InsertOne(produto);
            return produto;
        }
        public void Update(string id, Product produtoIn) => _products.ReplaceOne(produto => produto.Id == id, produtoIn);

        public void Remove(Product produtoIn) => _products.DeleteOne(produto => produto.Id == produtoIn.Id);

        public void Remove(string id) => _products.DeleteOne(produto => produto.Id == id);  
    }
}