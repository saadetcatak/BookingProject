namespace BookingProject.Dal.Entities
{
    public class Room
    {
        public string RoomID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Capacity { get; set; }
        public string Bed { get; set; }
        public string Services { get; set; }
        public decimal Price { get; set; }
    }
}
