using System;
using MediatR;
using Workers.Application.Data.DTOs;

namespace Workers.Application.WorkerPositions.Commands.AddWorkerPositions
{
    public class CreateWorkerPositionCommandHandler : IRequestHandler<CreateWorkerPositionCommand, WorkerPositionDto>
    {
        public Task<WorkerPositionDto> Handle(CreateWorkerPositionCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}

