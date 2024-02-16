using MediatR;
using Microsoft.AspNetCore.Mvc;
using Workers.Application.Data.DTOs;
using Workers.Application.WorkerPositions.Queries.GetWorkerPositions;

using Workers.Domain;
using Workers.Domain.Interfaces;
namespace Workers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerPositionController : ControllerBase
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IWorkerRepository _workerRepository;
        private readonly IWorkerPositionsRepository _workerPositionsRepository;
        private readonly IMediator _mediator;

        public WorkerPositionController(IWorkerRepository workerRepository, IGenderRepository genderRepository, IWorkerPositionsRepository workerPositionsRepository, IMediator mediator)
        {
            _workerRepository = workerRepository;
            _genderRepository = genderRepository;
            _workerPositionsRepository = workerPositionsRepository;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WorkerPositions>))]
        public async Task<IActionResult> GetGetWorkerPositions()
        {
            var response = await _mediator.Send(new GetWorkerPositionsQuery());
            return Ok(response);
        }

    }
}

