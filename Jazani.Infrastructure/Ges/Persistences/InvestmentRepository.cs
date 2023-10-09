using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Ges.Persistences
{
    public class InvestmentRepository : CrudRepository<Investment, int>, IInvestmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InvestmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<Investment>> FindAllAsync()
        {
            return await _dbContext.Set<Investment>()
                .Include(t => t.Holder)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Investment?> FindByIdAsync(int Id)
        {
            return await _dbContext.Set<Investment>()
                .Include(t => t.Holder)
                .FirstOrDefaultAsync(t => t.Id == Id);
        }
    }
}
