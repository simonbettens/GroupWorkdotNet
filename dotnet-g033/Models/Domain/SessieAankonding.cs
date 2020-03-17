using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public class SessieAankonding : Aankonding
    {

        #region Properties
        public Sessie Sessie { get; set; }
        public int SessieId { get; set; }
        #endregion

        #region Constructors
        public SessieAankonding() : base()
        {

        }
        public SessieAankonding(DateTime gepost, string inhoud, Verantwoordelijke verantwoordelijke, Sessie sessie ,AankondingPrioriteit prioriteit = AankondingPrioriteit.Laag) 
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
