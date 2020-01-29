using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OData.Gateway.Api.Services;

namespace OData.Gateway.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;

        private readonly IAccountsService _accountsService;

        public AccountsController(ILogger<AccountsController> logger, IAccountsService accountsService)
        {
            _logger = logger;
            _accountsService = accountsService;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get method called for Accounts");
            var accounts = await _accountsService.GetAll();
            return Ok(accounts.ToList());
        }

        [HttpGet]
        [EnableQuery()]
        public IActionResult Get(Guid id)
        {
            _logger.LogInformation($"Get method called for account id:{id}");
            var account = _accountsService.Get(id);
            return Ok(account);
        }
    }
}
