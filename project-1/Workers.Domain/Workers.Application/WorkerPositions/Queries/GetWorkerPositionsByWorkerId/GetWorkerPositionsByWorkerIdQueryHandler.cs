using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workers.Application.Data.DTOs;
using Workers.Domain.Interfaces;

namespace Workers.Application.WorkerPositions.Queries.GetWorkerPositionsByWorkerId
{
    public class GetWorkerPositionsByWorkerIdQueryHandler : IRequestHandler<GetWorkerPositionsByWorkerIdQuery, List<WorkerPositionDto>>
    {
        private readonly IWorkerPositionsRepository _workerPositionsRepository;

        public GetWorkerPositionsByWorkerIdQueryHandler(IWorkerPositionsRepository workerPositionsRepository) 
        {
            _workerPositionsRepository = workerPositionsRepository;
        }
        public async Task<List<WorkerPositionDto>> Handle(GetWorkerPositionsByWorkerIdQuery request, CancellationToken cancellationToken)
        {
            var workerPositionsByWorkerId = _workerPositionsRepository.GetWorkerPositionsByWorkerId(request.WorkerId);

            var WorkerPositionsList = workerPositionsByWorkerId.Select(wp => new WorkerPositionDto
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
