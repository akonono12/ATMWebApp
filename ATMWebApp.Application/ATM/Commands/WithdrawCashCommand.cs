using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMWebApp.Application.ATM.Commands
{
    public class WithdrawCashCommand : IRequest<bool>
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
