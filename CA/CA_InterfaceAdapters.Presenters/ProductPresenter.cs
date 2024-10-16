using CA_ApplicationLayer.Contracts;
using CA_EnterpriseLayer;

namespace CA_InterfaceAdapters.Presenters
{
    public class ProductPresenter : IPresenter<Product, ProductViewModel>
    {
        public IEnumerable<ProductViewModel> Present(IEnumerable<Product> data)
        {
            return data.Select(x => new ProductViewModel { 
                Description = $"Nombre producto: {x.Name}, Precio = {x.Price}"
            }).ToList();
        }
    }
}
