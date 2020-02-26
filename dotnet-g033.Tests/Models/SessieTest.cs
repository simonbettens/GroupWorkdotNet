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
        #region DisplayMedia_Test
        [Fact]
        public void DisplayAlleMedia_Link_Test()
        {
            Sessie1.VoegMediaToe(LinkGoogle);
            string uitkomst = "<li class=\"list-group-item\"><div>" +
                "<h4>Links:</h4>" +
                "<div>" +
                "<a href=\"https://www.google.be/\" target=\"_blank\">Klik hier om naar google te gaan</a>" +
                "</div>" +
                "</div></li>";
            Assert.Equal(uitkomst, Sessie1.DisplayAlleMedia());
        }
        [Fact]
        public void DisplayAlleMedia_Afbeelding_Test()
        {
            Sessie1.VoegMediaToe(Afbeelding);
            String uitkomst = "<li class=\"list-group-item\"><div>" +
                "<h4>Afbeeldingen:</h4>" +
                "<div class=\"row\"><div class=\"col-md-4\"><div class=\"thumbnail\">" +
                "<a href=\"test.jpg\" target=\"_blank\">" +
                "<img src=\"test.jpg\" alt=\"test.jpg\" style = \"width:100%\"> " +
                "<div class=\"caption\">" +
                "<p>test.jpg</p>" +
                "</div>" +
                "</a></div></div></div></div></li>";
            Assert.Equal(uitkomst, Sessie1.DisplayAlleMedia());
        }
        [Fact]
        public void DisplayAlleMedia_Video_Test()
        {
            Sessie1.VoegMediaToe(Video);
            String uitkomst = "<li class=\"list-group-item\"><div>" +
                "<h4>Video's:</h4><div>" +
                "<div class=\"embed-responsive embed-responsive-16by9\">" +
                "<video class=\"embed-responsive-item\" controls=\"true\" preload=\"auto\">" +
                "<source src=\"test.mp4\" type=\"video/mp4\">" +
                "</video>" +
                "</div>" +
                "<br/>" +
                "</div>" +
                "</div></li>";
            Assert.Equal(uitkomst, Sessie1.DisplayAlleMedia());
        }
        [Fact]
        public void DisplayAlleMedia_Document_Test()
        {
            Sessie1.VoegMediaToe(Document);
            string uitkomst = $"<li class=\"list-group-item\"><div>" +
                $"<h4>Documenten:</h4><div><table class=\"table\">" +
                $"<tr>" +
                $"<th></th>" +
                $"<th>Naam</th>" +
                $"<th>Datum Toegevoegd</th>" +
                $"</tr>" +
                $"<tr>" +
                $"<td>" +
                $"<span class=\"iconify\" data-icon=\"ant-design:file-word-filled\" data-inline=\"false\"></span>" +
                $"</td>" +
                $"<td><a href=\"{Document.Adress}\" target=\"_blank\">{Document.Naam}</a></td>" +
                $"<td>{Document.TijdToegevoegd.ToString("ddd dd/MM/yyyy, HH:mm")}</td>" +
                $"<tr></table></div>" +
                $"</div></li>";
            Assert.Equal(uitkomst, Sessie1.DisplayAlleMedia());
        }
        #endregion



    }
}
