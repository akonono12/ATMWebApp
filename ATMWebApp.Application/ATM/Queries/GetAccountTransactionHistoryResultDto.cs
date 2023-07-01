using ATMWebApp.Common.Enums;
using ATMWebApp.Domain.ATMManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMWebApp.Application.ATM.Queries
{
    public class GetAccountTransactionHistoryResultDto
    {
        public Guid TransactionHistoryId { get;  set; }
        public TransactionModes TransactionModes { get;  set; }
        public DateTime TransactionDate { get;  set; }
        public Decimal Amount { get;  set; }
    }
}
