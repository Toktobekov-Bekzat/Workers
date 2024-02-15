namespace Workers.Domain
{
    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // Navigation property for the workers in this position
        public ICollection<Worker> Workers { get; set; }
    }
}
