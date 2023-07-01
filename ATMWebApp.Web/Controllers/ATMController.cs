using ATMWebApp.Application.ATM.Commands;
using ATMWebApp.Application.ATM.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATMWebApp.Web.Controllers
{
    [ApiController]
    [Route("api/atm")]
    public class ATMController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ATMController(IMediator mediator) { 
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("account/{accountId}")]
        public async Task<IActionResult> GetAccount([FromRoute] string accountId)
        {
            var request = new GetAccountQuery()
            {
                AccountId = new Guid(accountId)
            };
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("transaction-histories/{accountId}")]
        public async Task<IActionResult> GetTransactionHistory([FromRoute] string accountId)
        {
            var request = new GetAccountTransactionHistoryListQuery()
            {
                AccountId = new Guid(accountId)
            };
            return Ok(await _mediator.Send(request));
        }

        [HttpPut("add")]

        public async Task<IActionResult> AddCash([FromBody] AddCashCommand request)
        {
            return Ok(await _mediator.Send(request));
        }


        [HttpPut("withdraw")]

        public async Task<IActionResult> WithdrawCash([FromBody] WithdrawCashCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

    }
}
