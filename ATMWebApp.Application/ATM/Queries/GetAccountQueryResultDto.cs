using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMWebApp.Application.ATM.Queries
{
    public class GetAccountQueryResultDto
    {
        public Guid AccountId { get;  set; }
        public string AccountName { get;  set; }
        public string AccountNumber { get;  set; }
        public decimal Balance { get;  set; }
        public DateTime? LastUpdated { get;  set; }
    }
}
