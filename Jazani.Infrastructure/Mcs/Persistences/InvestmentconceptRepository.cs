using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using System;

namespace Jazani.Infrastructure.Mcs.Persistences
{
    public class InvestmentconceptRepository : CrudRepository<Investmentconcept, int>, IInvestmentconceptRepository
    {
        public InvestmentconceptRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
