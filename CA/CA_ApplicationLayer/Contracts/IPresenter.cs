namespace CA_ApplicationLayer.Contracts
{
    public interface IPresenter<TEntity, TOutput>
    {
        public IEnumerable<TOutput> Present(IEnumerable<TEntity> data);
    }
}
