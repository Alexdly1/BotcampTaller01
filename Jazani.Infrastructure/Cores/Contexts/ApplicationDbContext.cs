using Jazani.Domain.Admins.Models;
using Jazani.Domain.Lias.Models;
using Jazani.Infrastructure.Admins.Configurations;
using Jazani.Infrastructure.Lias.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Cores.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }

        #region "DbSet"
        public DbSet<Process> Processes { get; set; }

        public DbSet<Activity> Activities { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProcessConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
        }
    }
}
