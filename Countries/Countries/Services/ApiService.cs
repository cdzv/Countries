using Countries.Models;
using Countries.ViewModels;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Countries.Services
{
    public class ApiService : IApiService
    {
        public async Task<Response> GetListAsync(
            string urlBase,
            string servicePrefix,
            string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var url = $"{servicePrefix}{controller}";
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var countries = JsonConvert.DeserializeObject<List<CountryItemViewModel>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = countries
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<bool> CheckConnectionAsync(string url)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return false;
            }

            return await CrossConnectivity.Current.IsRemoteReachable(url);
        }
    }
}
