using Jazani.Core.Paginations;
using Jazani.Domain.Cores.Paginations;
using Jazani.Domain.Mcs.Models;
using Jazani.Domain.Mcs.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Mcs.Persistences
{
    public class InvestmentRepository : CrudRepository<Investment, int>, IInvestmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPaginator<Investment> _paginator;

        public InvestmentRepository(ApplicationDbContext dbContext, IPaginator<Investment> paginator) : base(dbContext)
        {
            _dbContext = dbContext;
            _paginator = paginator;

        }

        public override async Task<IReadOnlyList<Investment>> FindAllAsync()
        {
            return await _dbContext.Set<Investment>()
                .Include(t => t.Holder)
                .Include(t => t.Investmentconcept)
                .Include(t => t.Investmenttype)
                .Include(t => t.Miningconcession)
                .Include(t => t.Periodtype)
                .Include(t => t.Measureunit)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Investment?> FindByIdAsync(int Id)
        {
            return await _dbContext.Set<Investment>()
                .Include(t => t.Holder)
                .Include(t => t.Investmentconcept)
                .Include(t => t.Investmenttype)
                .Include(t => t.Miningconcession)
                .Include(t => t.Periodtype)
                .Include(t => t.Measureunit)
                .FirstOrDefaultAsync(t => t.Id == Id);
        }

        public async Task<ResponsePagination<Investment>> PaginatedSearch(RequestPagination<Investment> request)
        {
            var filter = request.Filter;
            var query = _dbContext.Set<Investment>()
                .Include(t => t.Holder)
                .Include(t => t.Investmenttype)
                .Include(t => t.Miningconcession)
                .Include(t => t.Periodtype)
                .Include(t => t.Measureunit)
                .AsNoTracking()
                .AsQueryable();

            if (filter is not null)
            {
                query = query
                    .Where(x =>
                        (string.IsNullOrWhiteSpace(filter.Description) || x.Description.ToUpper().Contains(filter.Description.ToUpper()))
                        && (string.IsNullOrWhiteSpace(filter.AccreditationCode) || x.AccreditationCode.ToUpper().Contains(filter.AccreditationCode.ToUpper()))
                        && (string.IsNullOrWhiteSpace(filter.MonthName) || x.MonthName.ToUpper().Contains(filter.MonthName.ToUpper()))
                        && ((filter.State == null) || x.State == filter.State)
                        && ((filter.Year == null || filter.Year == 0) || x.Year == filter.Year)
                    );
            }
            query = query.OrderBy(x => x.Id);

            return await _paginator.Paginate(query, request);
        }

        public async override Task<Investment> SaveAsync(Investment entity)
        {
            EntityState state = _dbContext.Entry(entity).State;

            // entity.Investment = await _dbContext.Set<Investment>().FindAsync(entity.InvestmentId);
            _ = state switch
            {
                EntityState.Detached => _dbContext.Set<Investment>().Add(entity),
                EntityState.Modified => _dbContext.Set<Investment>().Update(entity)

            };

            await _dbContext.SaveChangesAsync();

            //return entity;

            return await FindByIdAsync(entity.Id);
        }
    }
}
