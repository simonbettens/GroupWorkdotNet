using dotnet_g033.Models.Domain;
using dotnet_g033.Tests.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_g033.Tests.Models
{
    public class MediaTest
    {
        public Media Media { get; set; }
        public Link LinkGoogle { get; set; }
        public Video Video { get; set; }
        public Afbeelding Afbeelding { get; set; }
        public Document Document { get; set; }
        private readonly DummyApplicationDbContext _dummyContext;

        public MediaTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            this.Media = _dummyContext.Media;
            this.LinkGoogle = _dummyContext.LinkGoogle;
            this.Video = _dummyContext.Video;
            this.Afbeelding = _dummyContext.Afbeelding;
            this.Document = _dummyContext.Word;
        }
        [Fact]
        public void VoegLinkToeTest() {
            Assert.Equal(0, Media.Linken.Count);
            Media.VoegLinkToe(LinkGoogle);
            Assert.Equal(1,Media.Linken.Count) ;
        }
        [Fact]
        public void VoegAfbeeldingToeTest() {
            Assert.Equal(0, Media.Afbeeldingen.Count);
            Media.VoegAfbeeldingToe(Afbeelding);
            Assert.Equal(1, Media.Afbeeldingen.Count);
        }
        [Fact]
        public void VoegVideoToeTest() {
            Assert.Equal(0, Media.Videos.Count);
            Media.VoegVideoToe(Video);
            Assert.Equal(1, Media.Videos.Count);
        }
        [Fact]
        public void VoegDocumentToeTest() {
            Assert.Equal(0, Media.Documenten.Count);
            Media.VoegDocumentToe(Document);
            Assert.Equal(1, Media.Documenten.Count);
        }
        [Fact]
        public void DisplayAlleMedia_GeenMedia_Test() {
            string uitkomst = "<p>Geen media om te tonen</p>";
            Assert.Equal(uitkomst, Media.DisplayAlleMedia());
        }
        [Fact]
        public void DisplayAlleMedia_Link_Test()
        {
            Media.VoegLinkToe(LinkGoogle);
            string uitkomst = "<h4>Linken:</h4><div><a href=\"https://www.google.be/\" target=\"_blank\">Klik hier om naar google te gaan</a></div>";
            Assert.Equal(uitkomst, Media.DisplayAlleMedia());
        }

    }
}
