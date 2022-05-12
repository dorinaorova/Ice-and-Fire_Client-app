using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KliensoldaliHf_GTAYJ0.Serives
{
    public  class CharacterService //singleton service class for characters
    {
        public static CharacterService Instance { get; } = new CharacterService();

        protected CharacterService() { }

        private readonly Uri serverUrl = new Uri("https://www.anapioficeandfire.com/"); //server base url
        //get all character
        public async Task<List<Character>> GetCharacters()
        {
            return await GetAsync<List<Character>>(new Uri(serverUrl, "api/characters"));
        }
        //get specific character by url
        public async Task<Character> GetCharacterAsync(string url)
        {
            return await GetAsync<Character>(new Uri(url));
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
