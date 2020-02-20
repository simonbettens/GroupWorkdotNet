
using dotnet_g033.Models.Domain;
using System;
using System.Collections.Generic;

namespace dotnet_g033.Tests.Data
{
    public class DummyApplicationDbContext
    {
        private readonly IList<Sessie> _sessies;
        private readonly IList<Sessie> _sessiesFeb;

        public Sessie Sessie1 { get; set; }
        public Sessie Sessie2 { get; set; }
        public Sessie Sessie3 { get; set; }
        public Sessie Sessie4 { get; set; }
        public Sessie Sessie5 { get; set; }
        public IEnumerable<Sessie> Sessies => _sessies;
        public IEnumerable<Sessie> SessiesFeb => _sessiesFeb;
        public DummyApplicationDbContext()
        {
            Sessie1 = new Sessie("sessie1", new DateTime(2020, 2, 20, 14, 0, 0), new DateTime(2020, 2, 20, 15, 0, 0), false, 20, 0, "GSCHB4.026");
            Sessie2 = new Sessie("sessie2", new DateTime(2020, 2, 21, 10, 30, 0), new DateTime(2020, 2, 21, 12, 30, 0), false, 10, 0, "GSCHB4.026");
            Sessie3 = new Sessie("sessie3", new DateTime(2020, 2, 22, 16, 0, 0), new DateTime(2020, 2, 22, 17, 0, 0), true, 30, 0, "GSCHB4.026");
            Sessie4 = new Sessie("sessie4", new DateTime(2020, 2, 19, 14, 0, 0), new DateTime(2020, 2, 19, 15, 0, 0), false, 20, 0, "GSCHB4.026");
            Sessie5 = new Sessie("sessie5", new DateTime(2020, 3, 19, 14, 0, 0), new DateTime(2020, 2, 19, 15, 0, 0), false, 20, 0, "GSCHB4.026");
            _sessies = new List<Sessie> { Sessie1, Sessie2, Sessie3, Sessie4, Sessie5 };
            _sessiesFeb = new List<Sessie> { Sessie1, Sessie2, Sessie3, Sessie4};
        }

    }
}
