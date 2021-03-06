using Flunt.Validations;
using TrafficTicket.Api.DataContracts.Queries;

namespace TrafficTicket.Api.Seedworks.ValidationContracts
{
    public class DateSearchQueryContract : Contract<DateSearchQuery>
    {
        public DateSearchQueryContract(DateSearchQuery search)
        {
            IsMinValue(search.CreatedSince, "Data de início invalida");
            IsMinValue(search.CreatedUntil, "Data de fim invalida");
            IsGreaterThan(search.CreatedSince, search.CreatedUntil, "Data de início invalida, a data de início deve ser menor que a data fim");
        }
    }
}
