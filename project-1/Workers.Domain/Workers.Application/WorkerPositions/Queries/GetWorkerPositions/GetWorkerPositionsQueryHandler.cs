using MediatR;
using Workers.Application.Data.DTOs;
using Workers.Domain.Interfaces;

namespace Workers.Application.WorkerPositions.Queries.GetWorkerPositions
{
    public class GetWorkerPositionsQueryHandler : IRequestHandler<GetWorkerPositionsQuery, List<WorkerPositionDto>>
	{
        private readonly IWorkerRepository _workerRepository;
        private readonly IWorkerPositionsRepository _workerPositionsRepository;

        public GetWorkerPositionsQueryHandler(IWorkerRepository workerRepository, IWorkerPositionsRepository workerPositionsRepository)
        {
            _workerRepository = workerRepository;
            _workerPositionsRepository = workerPositionsRepository;
        }

        public Task<List<WorkerPositionDto>> Handle(GetWorkerPositionsQuery request, CancellationToken cancellationToken)
        {
            var workerPositions = _workerPositionsRepository.GetWorkerPositions();

            var WorkerPositionsList = workerPositions.Select(wp => new WorkerPositionDto
            {
                FirstName = wp.Worker.FirstName,
                LastName = wp.Worker.LastName,
                Title = wp.Position.Title,
                StartDate = wp.StartDate,
                EndDate = wp.EndDate
            }).ToList();

            return Task.FromResult(WorkerPositionsList);
        }

    }
}

