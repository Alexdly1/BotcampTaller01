using Jazani.Domain.Socs.Repositories;
using Jazani.Domain.Socs.Models;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;

namespace Jazani.Infrastructure.Socs.Persistences
{
    public class HolderRepository : CrudRepository<Holder, int>, IHolderRepository
    {
        public HolderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
