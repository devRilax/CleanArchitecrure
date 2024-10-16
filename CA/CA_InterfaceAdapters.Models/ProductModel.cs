using CA_EnterpriseLayer;

namespace CA_InterfaceAdapters.Models
{
    public class ProductModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public int AvaibleQuantity { get; set; }
    }
}
