using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LeagueData
{
    public class Client
    {
        private readonly HttpClient _client;

        public Client()
        {
            _client = new HttpClient();
        }

        public async Task<HttpResponseMessage> Send(HttpMethod method, string url, IDictionary<string, string> headers)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = method
            };

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            return await _client.SendAsync(request);
        }
    }
}