using System;
using MediatR;
using Workers.Application.Data.DTOs;
using Workers.Domain.Interfaces;


namespace Workers.Application.Workers.Commands.Queries.GetWorkerById
{
    public class GetWorkerByIdQueryHandler : IRequestHandler<GetWorkerByIdQuery, WorkerDto>
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IGenderRepository _genderRepository;

        public GetWorkerByIdQueryHandler(IWorkerRepository workerRepository, IGenderRepository genderRepository)
        {
            _workerRepository = workerRepository;
            _genderRepository = genderRepository;
        }

        public async Task<WorkerDto> Handle(GetWorkerByIdQuery request, CancellationToken cancellationToken)
        {
            var worker = _workerRepository.GetWorkerById(request.WorkerId);

            if (worker == null)
            {
                return null; // Or handle the case when student is not found
            }

            var workerWithAgeandGender = new WorkerDto
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Gender = worker.Gender.Description,
                Age = WorkerDto.CalculateAge(worker.BirthDate),
                Position = worker.Position != null ? worker.Position.Title : "No Position"
            };

            return workerWithAgeandGender;
        }

    }
}

