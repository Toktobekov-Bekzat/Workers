using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workers.Application.Data.DTOs;

namespace Workers.Application.WorkerPositions.Queries.GetWorkerPositionsByWorkerId
{
    public class GetWorkerPositionsByWorkerIdQuery : IRequest<List<WorkerPositionDto>>
    {
        public int WorkerId { get; set; }
    }
}
