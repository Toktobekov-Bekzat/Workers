using System;
using MediatR;
using Workers.Application.Data.DTOs;

namespace Workers.Application.Workers.Commands.Queries.GetWorkerById
{
	public class GetWorkerByIdQuery : IRequest<WorkerDto>
	{
        public int WorkerId { get; set; }
    }
}

