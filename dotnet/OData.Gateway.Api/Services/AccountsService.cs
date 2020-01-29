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

        public Account Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            var users = await _accountsHtpClient.GetUsers();
            return users.Select(x => new Account
            {
                Id = Guid.NewGuid(),
                Name = x.Username,
                CreatedOn = DateTime.UtcNow,
            }).ToList();
            throw new NotImplementedException();
        }
    }
}
