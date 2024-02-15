using System;
using MediatR;
using Workers.Application.Data.DTOs;
using Workers.Domain.Interfaces;

namespace Workers.Application.Workers.Commands.DeleteWorkerById
{
    public class DeleteWorkerByIdCommandHandler : IRequestHandler<DeleteWorkerByIdCommand, WorkerDto>
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IGenderRepository _genderRepository;

        public DeleteWorkerByIdCommandHandler(IWorkerRepository workerRepository, IGenderRepository genderRepository)
        {
            _workerRepository = workerRepository;
            _genderRepository = genderRepository;
        }

        public async Task<WorkerDto> Handle(DeleteWorkerByIdCommand request, CancellationToken cancellationToken)
        {


            var worker = _workerRepository.GetWorkerById(request.WorkerId);

            var workerToReturn = new WorkerDto
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Gender = worker.Gender.Description,
                Age = WorkerDto.CalculateAge(worker.BirthDate)

            };

            _workerRepository.DeleteWorkerById(request.WorkerId);

            return workerToReturn;
        }
    }
}

