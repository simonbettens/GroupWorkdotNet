using System.Collections.Generic;

namespace dotnet_g033.Models.Domain
{
    public interface IGebruikerRepository
    {
        IEnumerable<Gebruiker> GetAll();
        Gebruiker GetByEmail(string name);
        Gebruiker GetByUsername(string username);
        Gebruiker GetById(long idNumber);
        Verantwoordelijke GetByUsernameIncludingBeheerdeSessies(string username);
        void SaveChanges();
    }
}
