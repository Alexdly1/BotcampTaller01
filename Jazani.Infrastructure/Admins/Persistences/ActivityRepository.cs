using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;


namespace Jazani.Infrastructure.Admins.Persistences
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public ActivityRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IReadOnlyList<Activity>> FindAllAsync()
        {
            return await _dbcontext.Activities.ToListAsync();
        }

        public async Task<Activity?> FindByIdAsync(int Id)
        {
            return await _dbcontext.Activities
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Activity> SaveAsync(Activity activity)
        {
            EntityState state = _dbcontext.Entry(activity).State;

            _ = state switch
            {
                EntityState.Detached => _dbcontext.Activities.Add(activity),
                EntityState.Modified => _dbcontext.Activities.Update(activity),
            };

            await _dbcontext.SaveChangesAsync();

            return activity;
        }
    }
}
