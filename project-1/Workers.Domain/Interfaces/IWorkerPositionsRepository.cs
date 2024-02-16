using System;
namespace Workers.Domain.Interfaces
{
	public interface IWorkerPositionsRepository
	{
		void CreateWorkerPosition(WorkerPositions workerPositon);
		ICollection<WorkerPositions> GetWorkerPositionsByPositionId(int PositionId);
		ICollection<WorkerPositions> GetWorkerPositions();
		ICollection <WorkerPositions> GetWorkerPositionsByWorkerId(int WorkerId);

	}
}

