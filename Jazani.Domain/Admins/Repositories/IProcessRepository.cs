using Jazani.Domain.Admins.Models;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IProcessRepository
    {
        Task<IReadOnlyList<Process>> FindAllAsync();
        Task<Process?> FindByIdAsync(int Id);
        Task<Process> SaveAsync(Process process);
    }
}
