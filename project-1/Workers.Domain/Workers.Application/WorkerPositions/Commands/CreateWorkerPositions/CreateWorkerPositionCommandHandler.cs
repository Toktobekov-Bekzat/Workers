using System;
using MediatR;
using Workers.Application.Data.DTOs;
using Workers.Domain;
using Workers.Domain.Interfaces;


namespace Workers.Application.WorkerPositions.Commands.AddWorkerPositions
{
    public class CreateWorkerPositionCommandHandler : IRequestHandler<CreateWorkerPositionCommand, WorkerPositionDto>
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IWorkerPositionsRepository _workerPositionsRepository;

        public CreateWorkerPositionCommandHandler(IWorkerRepository workerRepository, IPositionRepository positionRepository, IWorkerPositionsRepository workerPositionsRepository)
        {
            _workerRepository = workerRepository;
            _positionRepository = positionRepository;
            _workerPositionsRepository = workerPositionsRepository;
        }

        public async Task<WorkerPositionDto> Handle(CreateWorkerPositionCommand request, CancellationToken cancellationToken)
        {
            if (request == null) 
            {
                return null;
            }

            var workerPosition = new Domain.WorkerPositions
            {
                WorkerId = request.WorkerId,
                PositionId = request.PositionId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Worker = _workerRepository.GetWorkerById(request.WorkerId),
                Position = _positionRepository.GetPositionById(request.PositionId)
            };

            _workerPositionsRepository.CreateWorkerPosition(workerPosition);

            var workerPositionDto = new WorkerPositionDto
            {
                FirstName = workerPosition.Worker.FirstName,
                LastName = workerPosition.Worker.LastName,
                Title = workerPosition.Position.Title,
                StartDate = workerPosition.StartDate,
                EndDate = workerPosition.EndDate
            };
            return workerPositionDto;

        }
    }
}

