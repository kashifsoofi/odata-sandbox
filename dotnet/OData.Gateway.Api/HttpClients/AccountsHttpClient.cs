using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OData.Gateway.Api.HttpClients
{
    public class AccountsHtpClient : IAccountsHtpClient
    {
        public HttpClient Client { get; }

        public AccountsHtpClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            Client = client;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var response = await Client.GetAsync("/users");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<User>>(responseStream);
        }

        public async Task<User> GetUser(int id)
        {
            var response = await Client.GetAsync($"/users/{id}");
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<User>(responseStream);
        }
    }
}
