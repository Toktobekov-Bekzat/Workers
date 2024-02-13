namespace Workers.Domain
{
    public class WorkerPosition
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
