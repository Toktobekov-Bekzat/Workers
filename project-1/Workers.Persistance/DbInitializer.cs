using System;
namespace Workers.Persistance
{
	public class DbInitializer
	{
		public static void Initialize(WorkerDbContext context)
		{
			context.Database.EnsureCreated();
		}
	}
}

