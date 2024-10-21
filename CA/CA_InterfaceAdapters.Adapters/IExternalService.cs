namespace CA_InterfaceAdapters.Adapters
{
    public interface IExternalService<T>
    {
        Task<IEnumerable<T>> GetContentAsync();
    }
}
