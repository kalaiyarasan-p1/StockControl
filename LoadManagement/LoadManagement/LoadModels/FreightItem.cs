namespace LoadManagement.LoadModels
{
    public class FreightItem
    {
        public int FreightItemId { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public Carrier Carrier { get; set; }
    }
}
