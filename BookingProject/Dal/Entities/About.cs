using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookingProject.Dal.Entities
{
    public class About
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
    }
}
