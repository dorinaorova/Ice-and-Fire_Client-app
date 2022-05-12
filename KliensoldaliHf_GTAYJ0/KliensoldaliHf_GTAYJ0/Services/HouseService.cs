using KliensoldaliHf_GTAYJ0.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KliensoldaliHf_GTAYJ0.Serives
{
    public class HouseService  //singleton service class for houses
    {
        public static HouseService Instance { get; } = new HouseService();
        protected HouseService() { }

        private readonly Uri serverUrl = new Uri("https://www.anapioficeandfire.com/"); //api base url
        //get all houses
        public async Task<List<House>> GetHouses()
        {
            return await GetAsync<List<House>>(new Uri(serverUrl, "api/houses"));
        }
        //get specific house by url
        public async Task<House> GetHouseAsync(string url)
        {
            return await GetAsync<House>(new Uri(url));
        }
        //get task object async
        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }
    }
}
