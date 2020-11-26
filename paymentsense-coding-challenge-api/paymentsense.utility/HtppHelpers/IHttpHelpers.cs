using System.Threading.Tasks;

namespace paymentsense.utility.HtppHelpers
{
    public interface IHttpHelpers
    {
         Task<T> Get<T>(string url);
         Task<T> Post<T>(string url,T data);
    }
}
