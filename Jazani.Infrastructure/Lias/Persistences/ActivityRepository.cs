using Jazani.Domain.Lias.Models;
using Jazani.Domain.Lias.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;
using Jazani.Infrastructure.Cores.Persistences;


namespace Jazani.Infrastructure.Lias.Persistences
{
    public class ActivityRepository : CrudRepository<Activity, int>, IActivityRepository
    {
        public ActivityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
