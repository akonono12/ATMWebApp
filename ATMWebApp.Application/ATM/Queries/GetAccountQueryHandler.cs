using ATMWebApp.Domain.ATMManagement.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMWebApp.Application.ATM.Queries
{
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, GetAccountQueryResultDto>
    {
        private readonly IATMRepository _atmRepository;
        public GetAccountQueryHandler(IATMRepository atmRepository)
        {
            _atmRepository = atmRepository;
        }
        public async Task<GetAccountQueryResultDto> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var account =  _atmRepository.GetAllAccount()
                .SingleOrDefault(x => x.AccountId == request.AccountId);

            if (account != null) {

                GetAccountQueryResultDto result = new GetAccountQueryResultDto()
                {
                    AccountId = account.AccountId,
                    AccountName = account.AccountName,
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance,
                    LastUpdated = account.LastUpdated,
                };
                return result;
            }

            return new();
        }
    }
}
