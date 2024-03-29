﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Workers.Application.Data.DTOs;
using Workers.Application.WorkerPositions.Commands.AddWorkerPositions;
using Workers.Application.WorkerPositions.Queries.GetWorkerPositions;
using Workers.Application.WorkerPositions.Queries.GetWorkerPositionsByPositionId;
using Workers.Application.WorkerPositions.Queries.GetWorkerPositionsByWorkerId;
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

        [HttpGet("position/{PositionId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WorkerPositions>))]
        public async Task<IActionResult> GetWorkerPositionsByPositionId(int PositionId)
        {
            var request = new GetWorkerPositionsByPositionIdQuery { PositonId = PositionId };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("worker/{WorkerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WorkerPositions>))]
        public async Task<IActionResult> GetWorkerPositionsByWorkerId(int WorkerId)
        {
            var request = new GetWorkerPositionsByWorkerIdQuery { WorkerId = WorkerId };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateWorker([FromBody] CreateWorkerPositionCommand request)
        {
            var response = await _mediator.Send(request);

            if (response == null)
            {
                return BadRequest("Failed to add an entry.");
            }

            return Ok(response);
        }

    }
}

