using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_Asp.netAPI.Model
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Name")]
        public string BookName { get; set; } = null!;
        public decimal Price { get; set; }
        public string Category { get; set; }=null!;
        public string Auther { get; set; } = null!;
    }
}
