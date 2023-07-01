using ATMWebApp.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMWebApp.Domain.ATMManagement.Entities
{
    public class TransactionHistory
    {
        public Guid TransactionHistoryId { get; private set; }
        public TransactionModes TransactionModes { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public Decimal Amount { get; private set; }
        public Guid AccountId { get; private set; }
        public Account Account { get; private set; }

        private TransactionHistory() { }
        public TransactionHistory(TransactionModes transactionModes, decimal amount, Account account)
        {
            TransactionHistoryId = Guid.NewGuid();
            TransactionModes = transactionModes;
            TransactionDate = DateTime.Now;
            Amount = amount;
            AccountId = account.AccountId;
        }
    }
}
