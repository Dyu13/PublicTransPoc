using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Resources;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PublicTransportationPoc.Core.Models;

namespace PublicTransportationPoc.Core.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public DataService()
        {
            var rm = new ResourceManager(typeof(StringResource));
            var sqlConnectionString = rm.GetString("BaseUrlPublicServer");

            _httpClient.BaseAddress = new Uri(sqlConnectionString);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Route>> GetRoutes()
        {
            var url = "api/v1/routes";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var routesResponseJson = await response.Content.ReadAsStringAsync();
                    var routesResponse = JsonConvert.DeserializeObject<IEnumerable<Route>>(routesResponseJson);

                    return routesResponse;
                }

                var errorMessage = await response.Content.ReadAsStringAsync();

                // todo: log

                return null;
            }
            catch (Exception e)
            {
                //TODO: log
            }

            return null;
        }

        public async Task<Route> GetRouteById(Guid routeId)
        {
            var url = $"api/v1/routes/{routeId}";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var routeResponseJson = await response.Content.ReadAsStringAsync();
                    var routeResponse = JsonConvert.DeserializeObject<Route>(routeResponseJson);

                    return routeResponse;
                }

                var errorMessage = await response.Content.ReadAsStringAsync();

                // todo: log

                return null;
            }
            catch (Exception e)
            {
                //TODO: log
            }

            return null;
        }
    }
}