using CA_ApplicationLayer.Contracts;
using CA_EnterpriseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_ApplicationLayer.UseCases
{
    public class AddProductService<TDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper<TDto, Product> _mapper;

        public AddProductService(IRepository<Product> repository, IMapper<TDto, Product> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(TDto dto)
        {
            var producto = _mapper.ToEntity(dto);
            if (string.IsNullOrEmpty(producto.Name))
                throw new Exception("el nombre del producto es requerido");


        }
    }
}
