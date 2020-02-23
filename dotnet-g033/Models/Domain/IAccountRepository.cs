using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        IEnumerable<Account> GetByID(int id);
        Account GetById(int id);
        void SaveChanges();
    }
}
