using CA_ApplicationLayer.Contracts;
using CA_EnterpriseLayer;
using CA_InterfaceAdapters.Data;
using CA_InterfaceAdapters.Models;

namespace CA_InterfaceAdapters.Repository
{
    public class Repository : IRepository<Product>
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;    
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            //return await _dbContext.Products.ToListAsync();
            return new List<Product>()
            { 
                new Product() { Id = 123, Name = "NoTos", Price = 5000, AvaibleQuantity = 200 }
            };
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var model = await _dbContext.Products.FindAsync(id);

            if (model != null)
                return MapToEntity(model);

            return null;
        }

        private Product MapToEntity(ProductModel model)
        {
            return new Product()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                AvaibleQuantity = model.AvaibleQuantity
            };
        }

        private ProductModel MapToModel(Product entity)
        {
            return new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                AvaibleQuantity = entity.AvaibleQuantity
            };
        }
    }
}
