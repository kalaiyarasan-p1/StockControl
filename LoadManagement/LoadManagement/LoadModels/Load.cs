namespace LoadManagement.LoadModels
{
    public class Load
    {
        public int Id { get; set; }
        public Carrier Carrier { get; set; }
        public Customer Customer { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Status { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime DeliveryTime { get; set; }
        public List<LoadItem> LoadItems { get; set; }
    }
}
