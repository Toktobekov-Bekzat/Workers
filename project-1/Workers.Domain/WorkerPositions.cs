using System;

namespace Workers.Domain
{
	public class WorkerPositions
	{
		public int Id { get; set; }

		public int? WorkerId { get; set; }
		public int? PositionId { get; set; }

		public Worker? Worker { get; set; }
		public Position? Position { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

    }
}

