using System;
using MediatR;
using Workers.Application.Data.DTOs;

namespace Workers.Application.Workers.Commands.CreateWorker
{
	public class CreateWorkerCommand : IRequest<WorkerDto>
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public DateTime BirthDate { get; set; }
        public int PositionId { get; set; }
    }
}

