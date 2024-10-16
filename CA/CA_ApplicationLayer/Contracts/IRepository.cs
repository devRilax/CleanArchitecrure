namespace CA_ApplicationLayer.Contracts
{
    public interface IRepository<T>
    {
        Task <IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
