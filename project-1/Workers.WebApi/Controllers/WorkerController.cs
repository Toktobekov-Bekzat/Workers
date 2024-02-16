using MediatR;
using Microsoft.AspNetCore.Mvc;
using Workers.Application.Data.DTOs;
using Workers.Application.Workers.Commands.CreateWorker;
using Workers.Application.Workers.Commands.DeleteWorkerById;
using Workers.Application.Workers.Commands.Queries;
using Workers.Application.Workers.Commands.Queries.GetWorkerById;
using Workers.Domain;
using Workers.Domain.Interfaces;

namespace Workers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerRepository workerRepository;
        private readonly IGenderRepository genderRepository;
        private readonly IMediator _mediator;

        public WorkerController(IWorkerRepository workerRepository, IGenderRepository genderRepository, IMediator mediator)
        {
            this.workerRepository = workerRepository;
            this.genderRepository = genderRepository;
            this._mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Worker>))]
        public async Task<IActionResult> GetWorkers()
        {
            var response = await _mediator.Send(new GetWorkersQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(WorkerDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetWorkerById(int id)
        {
            var request = new GetWorkerByIdQuery { WorkerId = id };
            var response = await _mediator.Send(request);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateWorker([FromBody] CreateWorkerCommand request)
        {
            var response = await _mediator.Send(request);

            if (response == null)
            {
                return BadRequest("Failed to add student.");
            }

            return CreatedAtAction(nameof(GetWorkerById), new { id = response.Id }, response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(WorkerDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteStudentById(int id)
        {
            var request = new DeleteWorkerByIdCommand { WorkerId = id };
            var response = await _mediator.Send(request);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }



    }
}