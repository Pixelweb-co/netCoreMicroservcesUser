using MongoDB.Bson.Serialization.Attributes;

namespace SearchMicroService.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Nombres")]
        public string nombres { get; set; } = null!;

        [BsonElement("Usuario")]
        public string usuario { get; set; } = null!;
    }
}
