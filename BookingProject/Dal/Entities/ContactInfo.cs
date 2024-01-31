using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookingProject.Dal.Entities
{
    public class ContactInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactInfoID { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }

    }
}
