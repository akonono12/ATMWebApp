using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMWebApp.Application.ATM.Queries
{
    public class GetAccountTransactionHistoryListQuery: IRequest<List<GetAccountTransactionHistoryResultDto>>
    {
        public Guid AccountId { get; set; }
    }
}
