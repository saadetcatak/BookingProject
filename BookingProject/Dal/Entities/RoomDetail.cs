using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookingProject.Dal.Entities
{
    public class RoomDetail
    {
        public string RoomID { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
    }
}
