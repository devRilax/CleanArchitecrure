using CA_ApplicationLayer.Contracts;
using CA_EnterpriseLayer.Entities.Rest;
using CA_InterfaceAdapters.Adapters.Dto;

namespace CA_InterfaceAdapters.Adapters
{
    public class PostExternalServiceAdapter : IExternalServiceAdapter<Post>
    {
        private readonly IExternalService<PostDto> _service;

        public PostExternalServiceAdapter(IExternalService<PostDto> service)
        {
            _service = service;
        }

        public async Task<IEnumerable<Post>> GetDataAsync()
        {
            var data = await _service.GetContentAsync();

            return data.Select(sel => new Post()
            {
                Id = sel.Id,
                Name = sel.Name,
            }).ToList();
        }
    }
}
