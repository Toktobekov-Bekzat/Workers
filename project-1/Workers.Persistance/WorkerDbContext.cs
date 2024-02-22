using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Workers.Application.Interfaces;
using Workers.Domain;
using Workers.Persistance.EntityTypeConfiguration;

namespace Workers.Persistance
{
	public class WorkerDbContext : DbContext, Workers.Application.Interfaces.IWorkerDbContext
    {
		public DbSet<Worker> Workers { get; set; }
        public DbSet<Gender> Genders { get; set; }

        public DbSet<Position> Position { get; set; }
        public DbSet<WorkerPositions> WorkerPositions { get; set; }

        public WorkerDbContext(DbContextOptions<WorkerDbContext> options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Apply configuration for Worker entity
            builder.ApplyConfiguration(new WorkerConfiguration());

            // Define the relationship between Worker and Gender entities
            builder.Entity<Worker>()
                .HasOne(w => w.Gender)
                .WithMany()
                .HasForeignKey(w => w.GenderId)
                .OnDelete(DeleteBehavior.NoAction);

            // Define the primary key for the Position entity
            builder.Entity<Position>().HasKey(p => p.Id);

            // Seed data for Gender and Position entities
            builder.Entity<Gender>().HasData(
                new Gender { Id = 1, Description = "Male" },
                new Gender { Id = 2, Description = "Female" },
                new Gender { Id = 3, Description = "Non-binary" },
                new Gender { Id = 4, Description = "Prefer not to say" },
                new Gender { Id = 5, Description = "Other" }
            );

            builder.Entity<Position>().HasData(
                new Position { Id = 1, Title = "Software Engineer" },
                new Position { Id = 2, Title = "Data Scientist" },
                new Position { Id = 3, Title = "Product Manager" },
                new Position { Id = 4, Title = "UX/UI Designer" },
                new Position { Id = 5, Title = "QA Engineer" }
            );

            // Define primary key for Worker entity
            builder.Entity<Worker>().HasKey(w => w.Id);

            // Define relationship between Worker and Position entities
            builder.Entity<Worker>()
                .HasOne(w => w.Position)
                .WithMany(p => p.Workers)
                .HasForeignKey(w => w.PositionId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<WorkerPositions>()
            //    .HasOne(wp => wp.Worker)
            //    .WithMany(w => w.WorkerPositions)
            //    .HasForeignKey(wp => wp.WorkerId)
            //    .OnDelete(DeleteBehavior.NoAction); // or DeleteBehavior.SetNull, depending on your requirements

            //builder.Entity<WorkerPositions>()
            //    .HasOne(wp => wp.Position)
            //    .WithMany(p => p.WorkerPositions)
            //    .HasForeignKey(wp => wp.PositionId)
            //    .OnDelete(DeleteBehavior.NoAction); // or DeleteBehavior.SetNull

            // Call base method
            base.OnModelCreating(builder);
        }

    }
}

