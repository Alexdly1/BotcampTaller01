using Jazani.Domain.Mcs.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Jazani.Infrastructure.Mcs.Configurations
{
    public class MiningconcessionConfiguration : IEntityTypeConfiguration<Miningconcession>
    {
        public void Configure(EntityTypeBuilder<Miningconcession> builder)
        {
            builder.ToTable("miningconcession", "mc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DataTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}
