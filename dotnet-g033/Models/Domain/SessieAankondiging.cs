using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public class SessieAankondiging : Aankondiging
    {

        #region Properties
        public Sessie Sessie { get; set; }
        public int SessieId { get; set; }
        #endregion

        #region Constructors
        public SessieAankondiging() : base()
        {

        }
        public SessieAankondiging(DateTime gepost, string inhoud, Verantwoordelijke verantwoordelijke, Sessie sessie ,AankondigingPrioriteit prioriteit = AankondigingPrioriteit.Laag) 
            : base (gepost,inhoud,verantwoordelijke,prioriteit)
        {
            this.Sessie = sessie;
        }
        #endregion

        public void VoegAankondingToeAanSessie() {
            Sessie.Aankondingen.Add(this);
        }
    }
}
