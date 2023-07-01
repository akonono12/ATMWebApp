using ATMWebApp.Domain.ATMManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMWebApp.Domain.ATMManagement.Interfaces
{
    public interface IATMRepository
    {
         IQueryable<Account> GetAllAccount();
        void SaveChanges();

    }
}
