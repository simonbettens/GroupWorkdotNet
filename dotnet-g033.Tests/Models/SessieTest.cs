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
        public Sessie Sessie1 { get; set; } //toekomst
        public Sessie Sessie2 { get; set; } //verleden

        public Link LinkGoogle { get; set; }
        public Video Video { get; set; }
        public Afbeelding Afbeelding { get; set; }
        public Document Document { get; set; }
        public Gebruiker Gebruiker { get; set; }
        private readonly DummyApplicationDbContext _dummyContext;
        public Feedback Feedback { get; set; }
        public SessieTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            this.Sessie1 = _dummyContext.Sessie1;
            this.Sessie2 = _dummyContext.Sessie2;
            this.LinkGoogle = _dummyContext.LinkGoogle;
            this.Video = _dummyContext.Video;
            this.Afbeelding = _dummyContext.Afbeelding;
            this.Document = _dummyContext.Word;
            this.Gebruiker = _dummyContext.Gebruiker;
            this.Feedback = _dummyContext.Feedback;
        }

        [Fact]
        public void VoegMediaToe() {
            Sessie1.VoegMediaToe(LinkGoogle);
            Assert.True(Sessie1.Media.Count==1);
        }
        [Fact]
        public void SchrijfGebruikerIn_Test()
        {
            Assert.Equal(0, Gebruiker.SessiesIngeschreven.Count);
            Assert.Equal(0, Sessie1.AantalIngeschrevenGebruikers);
            SessieGebruiker sg = new SessieGebruiker(Sessie1, Gebruiker);
            Sessie1.SchrijfGebruikerIn(sg, Gebruiker);
            Assert.Equal(1, Gebruiker.SessiesIngeschreven.Count);
            Assert.Equal(1, Sessie1.AantalIngeschrevenGebruikers);
        }
        [Fact]
        public void SchrijfGebruikerUit_Test()
        {
            SessieGebruiker sg = new SessieGebruiker(Sessie1, Gebruiker);
            Sessie1.SchrijfGebruikerUit(sg, Gebruiker);
            Assert.Equal(0, Gebruiker.SessiesIngeschreven.Count);
            Assert.Equal(0, Sessie1.AantalIngeschrevenGebruikers);
        }
        [Fact]
        public void GeefSessieGebruiker_Test()
        {
            SessieGebruiker sg = new SessieGebruiker(Sessie1, Gebruiker);
            Sessie1.SchrijfGebruikerIn(sg, Gebruiker);
            Assert.Equal(sg.GebruikerId, Sessie1.GeefSessieGebruiker(Gebruiker).GebruikerId);
        }
        [Fact]
        public void GebruikerIsIngeschreven_Test()
        {
            SessieGebruiker sg = new SessieGebruiker(Sessie1, Gebruiker);
            Sessie1.SchrijfGebruikerIn(sg, Gebruiker);
            Assert.True(Sessie1.GebruikerIsIngeschreven(Gebruiker));
        }

        [Fact]
        public void StelGebruikerAanwezig_Test()
        {
            SessieGebruiker sg = new SessieGebruiker(Sessie1, Gebruiker);
            Sessie1.StelGebruikerAanwezig(sg);
            Assert.True(sg.Aanwezig);
        }
        [Fact]
        public void ZetOpen_Test()
        {
            Sessie1.StaatOpen = false;
            Sessie1.ZetOpen();
            Assert.True(Sessie1.StaatOpen);
        }
        [Fact]
        public void Sluit_Test()
        {
            Sessie1.StaatOpen = true;
            Sessie1.Sluit();
            Assert.False(Sessie1.StaatOpen);
        }
        [Fact]
        public void Feedback_OpSessieNietGestart()
        {
            Assert.Throws<ArgumentException>(() => Sessie1.VoegFeedbackToe(Feedback));
        }

        [Fact]
        public void Feedback_OpSessieGestart()
        {
            Sessie2.VoegFeedbackToe(Feedback);
            Assert.Single(Sessie2.GetFeedbacks());
        }


    }
}
