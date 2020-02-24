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
        public Sessie Sessie { get; set; }
    }
}
