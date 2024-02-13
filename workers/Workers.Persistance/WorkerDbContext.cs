using System;
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

		public WorkerDbContext(DbContextOptions<WorkerDbContext> options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new WorkerConfiguration());
			base.OnModelCreating(builder);
        }

    }
}

