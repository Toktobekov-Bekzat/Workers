namespace Workers.Domain
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        //Gender
        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        //Position
        public Position Position { get; set; }
        public int PositionId { get; set; }

        //WorkerPosition




    }
}
