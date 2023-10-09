using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using System;

namespace Jazani.Infrastructure.Mcs.Persistences
{
    public class InvestmenttypeRepository : CrudRepository<Investmenttype, int>, IInvestmenttypeRepository
    {
        public InvestmenttypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
