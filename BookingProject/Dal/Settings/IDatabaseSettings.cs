namespace BookingProject.Dal.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string AboutCollectionName { get; set; }
        public string BlogCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string ContactInfoCollectionName { get; set; }
        public string DiscoverCollectionName { get; set; }
        public string RoomDetailCollectionName { get; set; }
        public string ServiceCollectionName { get; set; }
        public string SubscribeCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }

    }
}
