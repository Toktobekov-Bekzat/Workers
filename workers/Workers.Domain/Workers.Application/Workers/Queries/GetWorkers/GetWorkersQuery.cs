using System;
using MediatR;
using Workers.Application.Data.DTOs;

namespace Workers.Application.Workers.Commands.Queries
{
	public class GetWorkersQuery : IRequest<List<WorkerDto>>
	{
		
	}
}

