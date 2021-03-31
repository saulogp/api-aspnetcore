using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace prjapiproduto.Models
{
    public class Provider
    {
        // [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
