using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workers.Domain;

namespace Workers.Persistance.EntityTypeConfiguration
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            // Define table name
            builder.ToTable("Workers");

            // Define primary key
            builder.HasKey(w => w.Id);

            // Define properties
            builder.Property(w => w.Id).HasColumnName("WorkerId");
            builder.Property(w => w.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(w => w.LastName).IsRequired().HasMaxLength(50);
            builder.Property(w => w.GenderId).IsRequired();
            builder.Property(w => w.BirthDate).IsRequired();

            // Define relationships
            builder.HasMany(w => w.WorkerPositions)
                   .WithOne(wp => wp.Worker)
                   .HasForeignKey(wp => wp.WorkerId);

            builder.HasOne(w => w.Gender)
                   .WithMany()
                   .HasForeignKey(w => w.GenderId);
        }
    }
}
