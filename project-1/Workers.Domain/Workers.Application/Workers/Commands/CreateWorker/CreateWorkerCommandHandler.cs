using System;
using MediatR;
using Workers.Application.Data.DTOs;
using Workers.Application.Interfaces;
using Workers.Domain;
using Workers.Domain.Interfaces;

namespace Workers.Application.Workers.Commands.CreateWorker
{
	public class CreateWorkerCommandHandler : IRequestHandler<CreateWorkerCommand, WorkerDto>
	{
        private readonly IWorkerRepository _workerRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly IPositionRepository _positionRepository;

        public CreateWorkerCommandHandler(IWorkerRepository workerRepository, IGenderRepository genderRepository, IPositionRepository positionRepository)
        {
            _workerRepository = workerRepository;
            _genderRepository = genderRepository;
            _positionRepository = positionRepository;
        }

        public async Task<WorkerDto> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.LastName))
            {
                return null; // Or handle validation error appropriately
            }

            var worker = new Worker
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                GenderId = request.GenderId,
                BirthDate = request.BirthDate,
                PositionId = request.PositionId
            };


            worker.Gender = _genderRepository.GetGenderByKey(worker.GenderId);


            _workerRepository.CreateWorker(worker);


            var workerDto = new WorkerDto
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Gender = worker.Gender.Description,
                Age = WorkerDto.CalculateAge(worker.BirthDate),
                Title = _positionRepository.GetPositionById(request.PositionId).Title

            };

            return workerDto;
        }
    }
}

