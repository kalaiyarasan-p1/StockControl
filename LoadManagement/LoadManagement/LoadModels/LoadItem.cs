namespace LoadManagement.LoadModels
{
    public class LoadItem
    {
        public int LoadItemId { get; set; }
        public Load Load { get; set; }
        public FreightItem FreightItem { get; set; }
        public int Quantity { get; set; }
    }
}
