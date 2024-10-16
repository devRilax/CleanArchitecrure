using CA_ApplicationLayer.Contracts;
using CA_EnterpriseLayer;
using CA_InterfaceAdapters.Mappers.Dto.Requests;

namespace CA_InterfaceAdapters.Mappers.Mapper
{
    public class ProductMapper : IMapper<ProductRequestDto, Product>
    {
        public Product ToEntity(ProductRequestDto dto)
            => new Product()
            {
                Id = dto.Id,
                Name = dto.Name
            };
    }
}
