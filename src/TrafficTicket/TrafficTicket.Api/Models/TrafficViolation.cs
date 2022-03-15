namespace TrafficTicket.Api.Models
{
    public class TrafficViolation
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
