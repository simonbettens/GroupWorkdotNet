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
        public bool ErZijnAankondingen => Aankondingen.Any();
        public bool ErZijnSessieAankondingen => SessieAankondingen.Any();
        #endregion

        #region Collections
        public IEnumerable<Aankonding> Aankondingen { get; set; }
        public IEnumerable<SessieAankonding> SessieAankondingen { get; set; } 
        #endregion

        public HomeIndexViewModel(IEnumerable<Aankonding> aankondingen, IEnumerable<SessieAankonding> sessieAankondingen,Sessie eerstVolgendeSessie,bool ingelogd)
        {
            this.Aankondingen = aankondingen;
            this.SessieAankondingen = sessieAankondingen;
            if (eerstVolgendeSessie != null)
            {
                this.EerstVolgendeSessie = eerstVolgendeSessie;
            }
            this.IsIngelogd = ingelogd;
        }
    }
}
