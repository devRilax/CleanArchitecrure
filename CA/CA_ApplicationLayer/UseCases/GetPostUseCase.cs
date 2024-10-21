using CA_ApplicationLayer.Contracts;
using CA_EnterpriseLayer.Entities.Rest;

namespace CA_ApplicationLayer.UseCases
{
    public class GetPostUseCase
    {
        private readonly IExternalServiceAdapter<Post> _serviceAdapter;

        public GetPostUseCase(IExternalServiceAdapter<Post> serviceAdapter)
        {
            _serviceAdapter = serviceAdapter;
        }

        public async Task<IEnumerable<Post>> ExecuteAsync()
        {
            return await _serviceAdapter.GetDataAsync();
        }
            
    }
}
