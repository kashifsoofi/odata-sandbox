using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OData.Gateway.Api.Models;

namespace OData.Gateway.Api.Services
{
    public interface IAccountsService
    {
        Task<IEnumerable<Account>> GetAll();
        Account Get(Guid id);
    }
}
