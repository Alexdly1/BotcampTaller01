using Jazani.Domain.Admins.Models;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IActivityRepository
    {
        Task<IReadOnlyList<Activity>> FindAllAsync();
        Task<Activity?> FindByIdAsync(int Id);
        Task<Activity> SaveAsync(Activity activity);
    }
}
