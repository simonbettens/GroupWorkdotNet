using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public class Aankondiging
    {
        #region Properties
        public int AankondingId { get; set; }
        public DateTime Gepost { get; set; }
        public string Inhoud { get; set; }
        public Verantwoordelijke Verantwoordelijke { get; set; } 
        public AankondigingPrioriteit Prioriteit { get; set; }
        #endregion

        #region Constructors
        public Aankondiging()
        {
            
        }
        public Aankondiging(DateTime gepost, string inhoud, Verantwoordelijke verantwoordelijke, AankondigingPrioriteit prioriteit = AankondigingPrioriteit.Laag)
        {
            this.Gepost = gepost;
            this.Inhoud = inhoud;
            this.Verantwoordelijke = verantwoordelijke;
            this.Prioriteit = prioriteit;
        } 
        #endregion


    }
}
