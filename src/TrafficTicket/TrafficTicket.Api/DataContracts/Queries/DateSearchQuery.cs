using Flunt.Notifications;
using TrafficTicket.Api.Seedworks.ValidationContracts;

namespace TrafficTicket.Api.DataContracts.Queries
{
    public class DateSearchQuery : Notifiable<Notification>
    {
        public DateTime CreatedSince { get; set; }

        public DateTime CreatedUntil { get; set; }

        public DateSearchQuery()
        {
            AddNotifications(new DateSearchQueryContract(this));
        }
    }
}
