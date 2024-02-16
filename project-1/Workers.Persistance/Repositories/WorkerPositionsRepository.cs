using System;
using Microsoft.EntityFrameworkCore;
using Workers.Application.Data.DTOs;
using Workers.Domain;
using Workers.Domain.Interfaces;

namespace Workers.Persistance.Repositories
{
    public class WorkerPositionsRepository : IWorkerPositionsRepository
    {
        private readonly WorkerDbContext _context;

        public WorkerPositionsRepository(WorkerDbContext context)
        {
            _context = context;
        }
        public void CreateWorkerPosition(WorkerPositions workerPosition)
        {
            _context.WorkerPositions.Add(workerPosition);
            _context.SaveChanges();
        }

        public ICollection<WorkerPositions> GetWorkerPositionsByPositionId(int PositionId)
        {
            return _context.WorkerPositions
                .Include(wp => wp.Worker)
                .Include(wp => wp.Position)
                .FirstOrDefault(wp => wp.PositionId == PositionId)
                .ToList();
        }

        public ICollection<WorkerPositions> GetWorkerPositions()
        {
            return _context.WorkerPositions
                .Include(wp => wp.Worker)
                .Include(wp => wp.Position)
                .ToList();
        }

        public ICollection<WorkerPositions> GetWorkerPositionsByWorkerId(int WorkerId)
        {
            return _context.WorkerPositions
                .Include(wp => wp.Worker)
                .Include(wp => wp.Position)
                .FirstOrDefault(wp => wp.WorkerId == WorkerId)
                .ToList();
        }

    }
}

