using System;
namespace Workers.Domain
{
	public class Position
	{
		public int Id { get; set; }
		public string Title { get; set; }

        public ICollection<WorkerPosition> WorkerPositions { get; set; }
    }
}

