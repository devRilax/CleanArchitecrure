using CA_ApplicationLayer.Contracts;
using System.Formats.Tar;

namespace CA_ApplicationLayer.UseCases
{
    public class GetProductService<TEntity, TOutput>
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IPresenter<TEntity, TOutput> _presenter;

        public GetProductService(IRepository<TEntity> repository, IPresenter<TEntity, TOutput> presenter)
        {
            _repository = repository;
            _presenter = presenter;
        }

        public async Task<IEnumerable<TOutput>> ExecuteAsync()
        {
            var data = await _repository.GetAllAsync();
            return _presenter.Present(data);
        }
    }
}
