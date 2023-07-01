using ATMWebApp.Domain.ATMManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMWebApp.Domain.ATMManagement
{
    public class ATMManagementDBContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
        public ATMManagementDBContext(DbContextOptions<ATMManagementDBContext>
        options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // If a tcpserver is deleted, set foreign key field in related Strings DB Table to null
            modelBuilder.Entity<Account>()
                        .HasMany(x => x.TransactionHistory)
                        .WithOne()
                        .HasForeignKey(x => x.AccountId);

            modelBuilder.Entity<TransactionHistory>()
                       .HasOne(x => x.Account)
                       .WithMany()
                       .HasForeignKey(x => x.TransactionHistoryId);
        }



    }
}
