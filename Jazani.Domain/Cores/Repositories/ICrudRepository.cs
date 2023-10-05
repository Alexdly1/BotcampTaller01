namespace Jazani.Domain.Cores.Repositories
{
    public interface ICrudRepository<T, ID>
    {
        Task<IReadOnlyList<T>> FindAllAsync();
        Task<T?> FindByIdAsync(ID Id);
        Task<T> SaveAsync(T entity);
    }
}
