using Jazani.Domain.Ges.Models;
using Jazani.Domain.Ges.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infrastructure.Ges.Persistences
{
    public class PeriodtypeRepository : CrudRepository<Periodtype, int>, IPeriodtypeRepository
    {
        public PeriodtypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
