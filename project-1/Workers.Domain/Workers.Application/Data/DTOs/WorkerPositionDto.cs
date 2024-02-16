using System;
namespace Workers.Application.Data.DTOs
{
    public class WorkerPositionDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

