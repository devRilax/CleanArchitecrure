namespace CA_EnterpriseLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public int AvaibleQuantity { get; set; }
        public bool HaveStock() => AvaibleQuantity > 0;
    }
}
