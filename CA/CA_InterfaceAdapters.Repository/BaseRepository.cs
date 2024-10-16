namespace CA_InterfaceAdapters.Repository
{
    public abstract class BaseRepository<TModel, TEntity>
    {
        public abstract TModel MapToModel(TEntity entity);
        public abstract TEntity MapToEntity(TModel model);
    }
}
