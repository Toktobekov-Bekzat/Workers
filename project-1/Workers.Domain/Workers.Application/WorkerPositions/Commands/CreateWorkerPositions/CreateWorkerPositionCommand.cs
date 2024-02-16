using System;
using MediatR;
using Workers.Application.Data.DTOs;

namespace Workers.Application.WorkerPositions.Commands.AddWorkerPositions
{
	public class CreateWorkerPositionCommand : IRequest<WorkerPositionDto>
	{
		public int WorkerId { get; set; }
		public int PositionId { get; set; }

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		
	}
}

