using ATMWebApp.Domain.ATMManagement.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMWebApp.Application.ATM.Commands
{
    public class WithdrawCashCommandHandler : IRequestHandler<WithdrawCashCommand, bool>
    {
        private readonly IATMRepository _atmRepository;
        public WithdrawCashCommandHandler(IATMRepository atmRepository)
        {
            _atmRepository = atmRepository;
        }
        public async Task<bool> Handle(WithdrawCashCommand request, CancellationToken cancellationToken)
        {
            var account = await _atmRepository.GetAllAccount()
              .Include(x => x.TransactionHistory)
              .SingleOrDefaultAsync(x => x.AccountId == request.AccountId);

            if (account != null)
            {
                account.WithdrawCash(request.Amount);
            }

             _atmRepository.SaveChanges();
            return account != null ? true : false;
        }
    }
}
