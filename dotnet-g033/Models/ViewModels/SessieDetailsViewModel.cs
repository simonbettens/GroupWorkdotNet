using dotnet_g033.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.ViewModels {
    public class SessieDetailsViewModel {
        public SessieDetailsViewModel(Sessie sessie) {
            this.Sessie = sessie;
        }

        /*public String Naam { get; set; }
public String Lokaal { get; set; }
public DateTime StartDatum { get; set; }
public DateTime EindDatum { get; set; }
public int AantalAanwezigeGebruikers { get; set; }
public int MaxCap { get; set; }*/
        public Sessie Sessie { get; set; }
    }
}
