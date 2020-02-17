using paymentsense.common.Contracts.Geographic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace paymentsense.geographic.business
{
    public interface IGeographic
    {
        Task<IEnumerable<Country>> GetCountries();
    }
}
