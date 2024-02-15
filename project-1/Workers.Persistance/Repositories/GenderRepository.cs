using System;
using Microsoft.EntityFrameworkCore;
using Workers.Domain;
using Workers.Domain.Interfaces;

namespace Workers.Persistance.Repositories
{
	public class GenderRepository : IGenderRepository
	{
        private readonly WorkerDbContext _context;

        public GenderRepository(WorkerDbContext context)
        {
            _context = context;
        }
        public Gender GetGenderByKey(int genderKey)
        {
            return _context.Genders.FirstOrDefault(g => g.Id == genderKey);
        }
    }
}

