using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Workers.Domain;

namespace Workers.Application.Interfaces
{
    public interface IWorkerDbContext
    {
        DbSet<Worker> Workers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
