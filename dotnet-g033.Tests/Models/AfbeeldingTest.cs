using dotnet_g033.Models.Domain;
using dotnet_g033.Tests.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_g033.Tests.Models
{
    public class AfbeeldingTest
    {
        public Afbeelding Afbeelding { get; set; }
        private readonly DummyApplicationDbContext _dummyContext;
        public AfbeeldingTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            this.Afbeelding = _dummyContext.Afbeelding;
        }
        
        
    }
}
