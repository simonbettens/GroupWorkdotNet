using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public interface ISessieRepository
    {
        IEnumerable<Sessie> GetAll();
        IEnumerable<Sessie> GetByMaandVerantwoordelijke(int maand);
        IEnumerable<Sessie> GetByMaand(int maand);
        IEnumerable<Sessie> GetSessieVerantwoordelijkeNogTeOpenen(Gebruiker g, int maand);
        IEnumerable<Sessie> GetSessieHoofdVerantwoordelijkeNogTeOpenen(Gebruiker g, int maandId);
        Sessie GetById(int id);
        void SaveChanges();
    }
}
