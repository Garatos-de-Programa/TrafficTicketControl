using MongoDB.Bson.Serialization.Attributes;

namespace TrafficTicket.Api.Models
{
    public class TrafficViolation
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedAt { get; set; }

        public TrafficViolation()
        {
        }

        public TrafficViolation(string id)
        {
            Id = id;
        }
    }
}
