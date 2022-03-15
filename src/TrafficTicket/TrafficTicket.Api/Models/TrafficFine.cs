﻿namespace TrafficTicket.Api.Models.TrafficFine
{
    public class TrafficFine
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Placa { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string Photo { get; set; }

        public bool Active { get; set; }

        public bool Computed { get; set; }

        public IEnumerable<TrafficViolation> TrafficViolations { get; set; }
    }
}
