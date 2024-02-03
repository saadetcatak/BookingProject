using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BookingProject.Dal.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialID { get; set; }
        public string Description { get; set; }
        public string NameSurname { get; set; }
    }
}
