using System;
using System.Collections.Generic; // Add this namespace for ICollection<T>
using Workers.Domain; // Add this namespace for Gender enum

namespace Workers.Domain
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; } // Assuming Gender is an enum defined in Workers.Domain.Enums
        public ICollection<WorkerPosition> WorkerPositions { get; set; }
    }
}
