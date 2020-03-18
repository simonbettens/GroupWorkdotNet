using dotnet_g033.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.ViewModels
{
    public class HomeIndexViewModel
    {

        #region Properties
        public Sessie EerstVolgendeSessie { get; set; }
        public string VerantwoordelijkeNaam => EerstVolgendeSessie.Verantwoordelijke.Voornaam + " " + EerstVolgendeSessie.Verantwoordelijke.Achternaam;
        public int AantalResterend => EerstVolgendeSessie.MaxCap - EerstVolgendeSessie.AantalIngeschrevenGebruikers;
        public bool KanNogInschrijven => AantalResterend > 0;
        public bool IsIngelogd { get; set; }
        public bool ErIsVolgendeSessie => EerstVolgendeSessie != null;
        public bool ErZijnAankondingen => Aankondigingen.Any();
        public bool ErZijnSessieAankondingen => SessieAankondigingen.Any();
        #endregion

        #region Collections
        public IEnumerable<Aankondiging> Aankondigingen { get; set; }
        public IEnumerable<SessieAankondiging> SessieAankondigingen { get; set; } 
        #endregion

        public HomeIndexViewModel(IEnumerable<Aankondiging> aankondigingen, IEnumerable<SessieAankondiging> sessieAankondigingen,Sessie eerstVolgendeSessie,bool ingelogd)
        {
            this.Aankondigingen = aankondigingen;
            this.SessieAankondigingen = sessieAankondigingen;
            if (eerstVolgendeSessie != null)
            {
                this.EerstVolgendeSessie = eerstVolgendeSessie;
            }
            this.IsIngelogd = ingelogd;
        }
    }
}
