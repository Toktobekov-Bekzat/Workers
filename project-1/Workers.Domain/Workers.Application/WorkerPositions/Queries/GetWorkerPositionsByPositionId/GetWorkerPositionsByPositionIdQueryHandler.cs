using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workers.Application.Data.DTOs;
using Workers.Domain;
using Workers.Domain.Interfaces;

namespace Workers.Application.WorkerPositions.Queries.GetWorkerPositionsByPositionId
{
    public class GetWorkerPositionsByPositionIdQueryHandler : IRequestHandler<GetWorkerPositionsByPositionIdQuery, List<WorkerPositionDto>>
    {

        private readonly IWorkerPositionsRepository _workerPositionRepository;

        public GetWorkerPositionsByPositionIdQueryHandler(IWorkerPositionsRepository workerPositionRepository)
        {
            _workerPositionRepository = workerPositionRepository;
        }
        public async Task<List<WorkerPositionDto>> Handle(GetWorkerPositionsByPositionIdQuery request, CancellationToken cancellationToken)
        {
            var workerPositionsByPositionId = _workerPositionRepository.GetWorkerPositionsByPositionId(request.PositonId);

            var WorkerPositionsList = workerPositionsByPositionId.Select(wp => new WorkerPositionDto
            {
                FirstName = wp.Worker.FirstName,
                LastName = wp.Worker.LastName,
                Title = wp.Position.Title,
                StartDate = wp.StartDate,
                EndDate = wp.EndDate
            }).ToList();

            return await Task.FromResult(WorkerPositionsList);


        }
    }
}
