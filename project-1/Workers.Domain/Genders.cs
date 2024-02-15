using System;
namespace Workers.Domain
{
    public class Gender
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Worker Worker { get; set; }
    }
}