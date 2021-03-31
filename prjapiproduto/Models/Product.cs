using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace prjapiproduto.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Provider Provider { get; set; }
    }
}
