using Jazani.Domain.Lias.Models;

namespace Jazani.Domain.Lias.Repositories
{
    public interface IActivityRepository
    {
        Task<IReadOnlyList<Activity>> FindAllAsync();
        Task<Activity?> FindByIdAsync(int Id);
        Task<Activity> SaveAsync(Activity activity);
    }
}
