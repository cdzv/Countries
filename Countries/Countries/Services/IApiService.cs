using Countries.Models;
using System.Threading.Tasks;

namespace Countries.Services
{
    public interface IApiService
    {
        Task<Response> GetCountries(
            string urlBase,
            string servicePrefix,
            string controller);
    }
}
