using Jazani.Domain.Lias.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Lias.Configurations
{
    public class ActivityTemplateConfiguration : IEntityTypeConfiguration<ActivityTemplate>
    {
        public void Configure(EntityTypeBuilder<ActivityTemplate> builder)
        {
            builder.ToTable("activitytemplate", "lia");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.ActivityTypeId).HasColumnName("activitytypeid");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate");
            builder.Property(t => t.State).HasColumnName("state");

            builder.HasOne(one => one.Activity).WithMany(many => many.ActivityTemplates)
                .HasForeignKey(fk => fk.ActivityTypeId);    
        }
    }
}
