using System;
using MediatR;
using Workers.Application.Data.DTOs;
using Workers.Domain.Interfaces;

namespace Workers.Application.Workers.Commands.Queries.GetWorkers
{
    public class GetWorkersQueryHandler : IRequestHandler<GetWorkersQuery, List<WorkerDto>>
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IGenderRepository _genderRepository;

        public GetWorkersQueryHandler(IWorkerRepository workerRepository, IGenderRepository genderRepository)
        {
            _workerRepository = workerRepository;
            _genderRepository = genderRepository;
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
                Age = WorkerDto.CalculateAge(s.BirthDate)
            }).ToList();

            return Task.FromResult(workersWithGenderAndAge);
        }
    }
}

