using dotnet_g033.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbSet<Account> _accounts;
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._accounts = context.Account;
        }

        public IEnumerable<Account> GetAll()
        {
            return _accounts.ToList();
        }

        public IEnumerable<Account> GetByID(int id)
        {
            return _accounts.Where(a => a.Id == id).OrderBy(a => a.Achternaam).ToList();
        }

        public Account GetById(int id)
        {
            return _accounts.Where(a => a.Id == id).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
