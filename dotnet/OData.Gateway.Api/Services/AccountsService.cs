using System;
using System.Collections.Generic;
using OData.Gateway.Api.HttpClients;
using OData.Gateway.Api.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OData.Gateway.Api.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsHtpClient _accountsHtpClient;

        public AccountsService(IAccountsHtpClient accountsHtpClient)
        {
            _accountsHtpClient = accountsHtpClient;
        }

        public async Task<Account> Get(int id)
        {
            var user = await _accountsHtpClient.GetUser(id);
            return new Account
            {
                Id = user.Id,
                Name = user.Username,
                CreatedOn = DateTime.Now,
            };
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            var users = await _accountsHtpClient.GetUsers();
            return users.Select(x => new Account
            {
                Id = x.Id,
                Name = x.Username,
                CreatedOn = DateTime.UtcNow,
            }).ToList();
        }
    }
}
