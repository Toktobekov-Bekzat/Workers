using System;
using Microsoft.EntityFrameworkCore;
using Workers.Domain;
using Workers.Domain.Interfaces;

namespace Workers.Persistance.Repositories
{
	public class WorkerRepository : IWorkerRepository
	{
        private readonly WorkerDbContext _context;

        public WorkerRepository(WorkerDbContext context)
        {
            _context = context;
        }


        public void CreateWorker(Worker worker)
        {
            _context.Workers.Add(worker);
            _context.SaveChanges();
        }

        public void DeleteWorkerById(int id)
        {
            _context.Workers.Remove(GetWorkerById(id));
            _context.SaveChanges();
        }

        public Worker GetWorkerById(int id)
        {
            return _context.Workers
                .Include(s => s.Gender)
                .Include(s => s.Position)
                .FirstOrDefault(s => s.Id == id);
        }

        public ICollection<Worker> GetWorkers()
        {
            return _context.Workers
                .Include(s => s.Gender)
                .Include(s => s.Position)
                .ToList();
        }
    }
}

