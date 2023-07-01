using ATMWebApp.Domain.ATMManagement.Entities;
using ATMWebApp.Domain.ATMManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ATMWebApp.Domain.ATMManagement.Repositories
{
    public class ATMRepository:IATMRepository
    {
        private readonly ATMManagementDBContext _dbContext;
        public ATMRepository(ATMManagementDBContext dBContext) {
            _dbContext = dBContext;
        }

        public IQueryable<Account> GetAllAccount()
        {
            var result = _dbContext.Accounts;
            return result.AsQueryable();
        }

        public async void SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
