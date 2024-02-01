using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookingProject.Dal.Entities
{
    public class Blog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BlogID { get; set; }
        public string BlogName { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
