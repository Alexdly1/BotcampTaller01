using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;


namespace Jazani.Infrastructure.Admins.Persistences
{
    public class ProcessRepository : IProcessRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public ProcessRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IReadOnlyList<Process>> FindAllAsync()
        {
            return await _dbcontext.Processes.ToListAsync();
        }

        public async Task<Process?> FindByIdAsync(int Id)
        {
            return await _dbcontext.Processes
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Process> SaveAsync(Process process)
        {
            EntityState state = _dbcontext.Entry(process).State;

            _ = state switch
            {
                EntityState.Detached => _dbcontext.Processes.Add(process),
                EntityState.Modified => _dbcontext.Processes.Update(process),
            };

            await _dbcontext.SaveChangesAsync();

            return process;
        }
    }
}
