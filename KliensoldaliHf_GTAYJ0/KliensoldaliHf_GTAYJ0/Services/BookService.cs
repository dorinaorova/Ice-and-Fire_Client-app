using KliensoldaliHf_GTAYJ0.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KliensoldaliHf_GTAYJ0
{
    public  class BookService //singleton service class for books
    {
        public static BookService Instance { get; } = new BookService();

        protected BookService() { }

        private readonly Uri serverUrl = new Uri("https://www.anapioficeandfire.com/"); //base server url
        //get specific book by url
        public async Task<Book> GetBookAsync(string url)
        {
            return await GetAsync<Book>(new Uri(url));
        }
        //get all books
        public async Task<List<Book>> GetBooks()
        {
            return await GetAsync<List<Book>>(new Uri(serverUrl, "api/books"));
        }

        //get object async
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
