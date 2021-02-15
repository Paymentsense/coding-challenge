using System.Collections.Generic;

namespace Paymentsense.Coding.Challenge.Api.Models
{
    public class CountryForPaginationResponse
    {
        public IEnumerable<CountryForPagination> Countries {get;set;}

        public PaginationMeta Meta { get; set; }
    }
}
