using Jazani.Domain.Mcs.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Ges.Configurations
{
    public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            builder.ToTable("investment", "mc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.HolderId).HasColumnName("holderid");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DataTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");

            builder.HasOne(one => one.Holder).WithMany(many => many.Investments)
                .HasForeignKey(fk => fk.HolderId);
        }
    }
}
