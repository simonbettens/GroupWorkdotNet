using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public interface IAankondigingRepository
    {
        IEnumerable<Aankondiging> GetAllAlgemene();
        Aankondiging GetAankondingById(int id);
        Aankondiging GetSessieAankondingById(int id);
        IEnumerable<SessieAankondiging> GetAllSessieAankonding(int sessieId);

    }
}
