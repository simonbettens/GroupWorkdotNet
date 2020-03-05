using dotnet_g033.Models.Domain;
using dotnet_g033.Tests.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_g033.Tests.Models
{
    public class SessieTest
    {
        public Sessie Sessie1 { get; set; }
        public Sessie Sessie2 { get; set; }
        public Link LinkGoogle { get; set; }
        public Video Video { get; set; }
        public Afbeelding Afbeelding { get; set; }
        public Document Document { get; set; }
        private readonly DummyApplicationDbContext _dummyContext;
        public SessieTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            this.Sessie1 = _dummyContext.Sessie1;
            this.Sessie2 = _dummyContext.Sessie2;
            this.LinkGoogle = _dummyContext.LinkGoogle;
            this.Video = _dummyContext.Video;
            this.Afbeelding = _dummyContext.Afbeelding;
            this.Document = _dummyContext.Word;
        }
        [Fact]
        public void VoegMediaToe() {
            Sessie1.VoegMediaToe(LinkGoogle);
            Assert.True(Sessie1.Media.Count==1);
        }
        

    }
}
