using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookingProject.Dal.Entities
{
    public class Service
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ServicesID { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
