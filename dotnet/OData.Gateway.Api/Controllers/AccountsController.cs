using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OData.Gateway.Api.Services;

namespace OData.Gateway.Api.Controllers
{
    public class AccountsController : ODataController
    {
        private readonly ILogger<AccountsController> _logger;

        private readonly IAccountsService _accountsService;

        public AccountsController(ILogger<AccountsController> logger, IAccountsService accountsService)
        {
            _logger = logger;
            _accountsService = accountsService;
        }

        [EnableQuery()]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get method called for Accounts");
            var accounts = await _accountsService.GetAll();
            return Ok(accounts.ToList());
        }

        [EnableQuery()]
        public async Task<IActionResult> Get(int key)
        {
            _logger.LogInformation($"Get method called for account id:{key}");
            var account = await _accountsService.Get(key);
            return Ok(account);
        }
    }
}
