using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OData.Gateway.Api.Models;

namespace OData.Gateway.Api.HttpClients
{
    public interface IAccountsHtpClient
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
    }
}
