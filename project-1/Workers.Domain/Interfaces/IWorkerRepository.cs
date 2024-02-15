using System;
namespace Workers.Domain.Interfaces
{
    public interface IWorkerRepository
    {
        Worker GetWorkerById(int id);
        ICollection<Worker> GetWorkers();
        void CreateWorker(Worker worker);
        void DeleteWorkerById(int id);
    }
}

