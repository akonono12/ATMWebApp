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
    public class AddCashCommandHandler : IRequestHandler<AddCashCommand, bool>
    {
        private readonly IATMRepository _atmRepository;
        public AddCashCommandHandler(IATMRepository atmRepository)
        {
            _atmRepository = atmRepository;
        }

        public async Task<bool> Handle(AddCashCommand request, CancellationToken cancellationToken)
        {
            var account =   _atmRepository.GetAllAccount()
                .Include(x => x.TransactionHistory)
                .SingleOrDefault(x => x.AccountId == request.AccountId);

            if(account != null) {
                account.AddCash(request.Amount);
            }

             _atmRepository.SaveChanges();
            return account != null ? true:false;
        }
    }
}
