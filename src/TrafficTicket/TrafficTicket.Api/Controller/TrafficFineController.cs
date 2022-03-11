using TrafficTicket.Api.Repositories;

namespace TrafficTicket.Api.Controller
{
    public class TrafficFineController
    {
        private readonly ITrafficFineRepository _trafficFineRepository;

        public TrafficFineController(ITrafficFineRepository trafficFineRepository)
        {
            _trafficFineRepository = trafficFineRepository;
        }


    }
}
