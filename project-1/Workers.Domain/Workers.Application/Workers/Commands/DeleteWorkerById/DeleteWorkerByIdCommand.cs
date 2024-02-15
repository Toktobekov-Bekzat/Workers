using System;
using MediatR;
using Workers.Application.Data.DTOs;

namespace Workers.Application.Workers.Commands.DeleteWorkerById
{
	public class DeleteWorkerByIdCommand : IRequest<WorkerDto>
	{
		public int WorkerId { get; set; }
	}
}

