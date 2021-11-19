using MoviesTool.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTool.Common.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient httpClient;
        private string BaseUrl = "";
        private string ApiKey = "dad8a59d86a2793dda93aa485f7339c1";

        public MovieService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task GetAllAsync()
        {
            var httpResponse = await httpClient.GetAsync(BaseUrl+ "?api_key=" + ApiKey);
            var content = await httpResponse.Content.ReadAsStringAsync();
        }

        public async Task GetAllPopularAsync(int page)
        {
            string req = httpClient.BaseAddress + "popular?api_key=" + ApiKey + "&language=en-US&page=" + page;
            var httpResponse = await httpClient.GetAsync(httpClient.BaseAddress + "popular?api_key=" + ApiKey + "&language=en-US&page=" + page);
            var content = await httpResponse.Content.ReadAsStringAsync();
        }
    }
}
