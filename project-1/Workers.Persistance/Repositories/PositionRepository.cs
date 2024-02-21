using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workers.Domain;
using Workers.Domain.Interfaces;
namespace Workers.Persistance.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly WorkerDbContext _context;

        public PositionRepository(WorkerDbContext context)
        {
            _context = context;
        }

        public void Add(Position position)
        {
            _context.Position.Add(position);
            _context.SaveChanges();
        }

        public Position GetPositionById(int positionId)
        {
            return _context.Position
                .FirstOrDefault(p => p.Id == positionId);
        }
    }
}
