using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public interface IAankondingRepository
    {
        IEnumerable<Aankonding> GetAllAlgemene();
        Aankonding GetAankondingById(int id);
        Aankonding GetSessieAankondingById(int id);
        IEnumerable<SessieAankonding> GetAllSessieAankonding(int sessieId);

    }
}
