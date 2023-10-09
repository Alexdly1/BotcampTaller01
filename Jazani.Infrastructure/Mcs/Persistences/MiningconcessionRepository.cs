using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using System;

namespace Jazani.Infrastructure.Mcs.Persistences
{
    public class MiningconcessionRepository : CrudRepository<Miningconcession, int>, IMiningconcessionRepository
    {
        public MiningconcessionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
