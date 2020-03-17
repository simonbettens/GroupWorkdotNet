using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public class Aankonding
    {
        #region Properties
        public int AankondingId { get; set; }
        public DateTime Gepost { get; set; }
        public string Inhoud { get; set; }
        public Verantwoordelijke Verantwoordelijke { get; set; } 
        public AankondingPrioriteit Prioriteit { get; set; }
        #endregion

        #region Constructors
        public Aankonding()
        {
            
        }
        public Aankonding(DateTime gepost, string inhoud, Verantwoordelijke verantwoordelijke, AankondingPrioriteit prioriteit = AankondingPrioriteit.Laag)
        {
            this.Gepost = gepost;
            this.Inhoud = inhoud;
            this.Verantwoordelijke = verantwoordelijke;
            this.Prioriteit = prioriteit;
        } 
        #endregion


    }
}
