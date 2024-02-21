using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workers.Application.Data.DTOs;

namespace Workers.Application.WorkerPositions.Queries.GetWorkerPositionsByPositionId
{
    public class GetWorkerPositionsByPositionIdQuery : IRequest<List<WorkerPositionDto>>
    {
        public int PositonId { get; set; }
    }
}
