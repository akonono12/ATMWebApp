using ATMWebApp.Domain.ATMManagement.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ATMWebApp.Application.ATM.Queries
{
    public class GetAccountTransactionHistoryListQueryHandler : IRequestHandler<GetAccountTransactionHistoryListQuery, List<GetAccountTransactionHistoryResultDto>>
    { 
        private readonly IATMRepository _atmRepository;
        public GetAccountTransactionHistoryListQueryHandler(IATMRepository atmRepository) { 
            _atmRepository = atmRepository;
        }
        public async Task<List<GetAccountTransactionHistoryResultDto>> Handle(GetAccountTransactionHistoryListQuery request, CancellationToken cancellationToken)
        {
            var transactionHistories =  _atmRepository.GetAllAccount()
                .Include(x => x.TransactionHistory)
                .Where(x => x.AccountId == request.AccountId)
                .SelectMany(x => x.TransactionHistory)
                .OrderByDescending(x => x.TransactionDate)
                .ToList();

            List<GetAccountTransactionHistoryResultDto> result = new List<GetAccountTransactionHistoryResultDto>();

            if(transactionHistories.Any()) {
                foreach (var transactionHistory in transactionHistories)
                {
                    result.Add(new GetAccountTransactionHistoryResultDto()
                    {
                        TransactionDate = transactionHistory.TransactionDate,
                        Amount = transactionHistory.Amount,
                        TransactionHistoryId = transactionHistory.TransactionHistoryId,
                        TransactionModes = transactionHistory.TransactionModes
                    });
                }
            }
          
                
            return result;
        }
    }
}
