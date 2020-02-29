using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public interface IGebruikerRepository
    {
        IEnumerable<Gebruiker> GetAll();
        IEnumerable<Gebruiker> GetByID(int idNumber);
        Gebruiker GetById(int idNumber);
        void SaveChanges();
        Gebruiker GetByEmail(string name);
    }
}
