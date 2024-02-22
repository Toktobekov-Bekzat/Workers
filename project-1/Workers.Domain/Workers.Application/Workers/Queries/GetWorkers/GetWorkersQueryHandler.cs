using System;
using MediatR;
using Workers.Application.Data.DTOs;
using Workers.Domain.Interfaces;

namespace Workers.Application.Workers.Commands.Queries.GetWorkers
{
    public class GetWorkersQueryHandler : IRequestHandler<GetWorkersQuery, List<WorkerDto>>
    {
        private readonly IWorkerRepository _workerRepository;

        public GetWorkersQueryHandler(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public Task<List<WorkerDto>> Handle(GetWorkersQuery request, CancellationToken cancellationToken)
        {
            var workersWithGender = _workerRepository.GetWorkers();

            var workersWithGenderAndAge = workersWithGender.Select(s => new WorkerDto
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Gender = s.Gender.Description,
                Age = WorkerDto.CalculateAge(s.BirthDate),
                Title = s.Position != null ? s.Position.Title : "No Position" // Handle null position
            }).ToList();


            return Task.FromResult(workersWithGenderAndAge);
        }
    }
}

