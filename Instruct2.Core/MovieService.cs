using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Instruct2.Core
{
    public class MovieService
    {
        private string _serverAddress = "http://192.168.1.105:1337";

        public MovieService(string serverAddress)
        {
            _serverAddress = serverAddress;
        }

        public MovieService()
        {
        }

        public async Task<MovieList> GetTop100MoviesOfAllTime()
        {
            var movieList = new MovieList();
            try
            {
                var client = CreateHttpClient();

                var response = client.GetAsync("movies").Result;
                var content = await response.Content.ReadAsStringAsync();

                movieList = ConvertResponseToMovieList(content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return movieList;
        }

        private static MovieList ConvertResponseToMovieList(string content)
        {
            return JsonConvert.DeserializeObject<MovieList>(content);
        }

        private HttpClient CreateHttpClient()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(_serverAddress);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
