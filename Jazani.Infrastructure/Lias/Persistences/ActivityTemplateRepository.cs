using System;
using Jazani.Domain.Lias.Models;
using Jazani.Domain.Lias.Repositories;
using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Lias.Persistences
{
    public class ActivityTemplateRepository : CrudRepository<ActivityTemplate, int>, IActivityTemplateRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ActivityTemplateRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<ActivityTemplate>> FindAllAsync()
        {
            return await _dbContext.Set<ActivityTemplate>()
                .Include(t => t.Activity)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<ActivityTemplate?> FindByIdAsync(int Id)
        {
            return await _dbContext.Set<ActivityTemplate>()
                .Include(t => t.Activity)
                .FirstOrDefaultAsync(t => t.Id == Id);
        }
    }
}
