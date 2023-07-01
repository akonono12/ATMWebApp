using ATMWebApp.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMWebApp.Domain.ATMManagement.Entities
{
    public class Account
    {
        private List<TransactionHistory> _transactionHistoy = new List<TransactionHistory>();
        public Guid AccountId { get; private set; }
        public string AccountName { get; private set; }
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public int Pin { get; private set; }
        public string Password { get; private set; }
        public DateTime? LastUpdated { get; private set; }
        public IReadOnlyCollection<TransactionHistory> TransactionHistory => _transactionHistoy;

        private Account() { }
        public Account(string accountName, decimal balance,int pin,string password) { 
            this.AccountId = Guid.NewGuid();
            this.AccountName = accountName;
            this.AccountNumber = this.RandomDigits(10);
            this.Balance = balance;
            this.Pin = pin;
            this.Password = password;
        }

        public void WithdrawCash(decimal cash)
        {
            this.Balance -= cash;
            this.LastUpdated = DateTime.Now;
            this.SetTransaction(TransactionModes.Withdraw, cash);
        }

        public void AddCash(decimal cash)
        {
            this.Balance += cash;
            this.LastUpdated = DateTime.Now;
            this.SetTransaction(TransactionModes.Add, cash);
        }

        private void SetTransaction(TransactionModes transactionModes, decimal amount)
        {
            var transactionHistory = new TransactionHistory(transactionModes, amount, this);
            _transactionHistoy.Add(transactionHistory);
        }

        private string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

    }
}
