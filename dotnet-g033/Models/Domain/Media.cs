using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public abstract class Media
    {
        public int Id { get; set; }
        public String Adress { get; set; }
        public String Naam { get; set; }
        public DateTime TijdToegevoegd { get; set; }
        public MediaType MediaType { get; set; }
       
    }
}
