using Countries.Models;
using System.Threading.Tasks;

namespace Countries.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync(
            string urlBase,
            string servicePrefix,
            string controller);

        Task<bool> CheckConnectionAsync(string url);
    }
}
