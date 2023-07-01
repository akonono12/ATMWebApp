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
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Guid>
    {
        private readonly IATMRepository _atmRepository;

        public LoginCommandHandler(IATMRepository atmRepository) { 
            _atmRepository = atmRepository;
        }
        public async Task<Guid> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var account =  _atmRepository.GetAllAccount()
                .SingleOrDefault(x => x.Pin == request.Pin || x.Password == request.Password);

            return account == null ? Guid.Empty:account.AccountId;
        }
    }
}
