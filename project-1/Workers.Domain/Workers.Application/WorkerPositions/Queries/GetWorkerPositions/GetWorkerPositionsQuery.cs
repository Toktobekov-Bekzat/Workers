using MediatR;
using Workers.Application.Data.DTOs;

namespace Workers.Application.WorkerPositions.Queries.GetWorkerPositions
{
    public class GetWorkerPositionsQuery : IRequest<List<WorkerPositionDto>>
    {
    }
}