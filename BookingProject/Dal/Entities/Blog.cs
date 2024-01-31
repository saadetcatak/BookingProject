using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookingProject.Dal.Entities
{
    public class Blog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BlogsID { get; set; }
        public string BlogsName { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
