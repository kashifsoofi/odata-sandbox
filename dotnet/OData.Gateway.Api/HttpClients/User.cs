using System;
namespace OData.Gateway.Api.HttpClients
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        public Address Address { get; set; }
    }
}
