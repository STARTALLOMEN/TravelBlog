namespace API.Data.Entities
{
    public class MarkDestination
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
