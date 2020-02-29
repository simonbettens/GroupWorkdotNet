
using dotnet_g033.Models.Domain;
using System;
using System.Collections.Generic;

namespace dotnet_g033.Tests.Data
{
    public class DummyApplicationDbContext
    {
        private readonly IList<Sessie> _sessies;
        private readonly IList<Sessie> _sessiesFeb;
        #region Properties
        public Sessie Sessie1 { get; set; }
        public Sessie Sessie2 { get; set; }
        public Sessie Sessie3 { get; set; }
        public Sessie Sessie4 { get; set; }
        public Sessie Sessie5 { get; set; }
        public IEnumerable<Sessie> Sessies => _sessies;
        public IEnumerable<Sessie> SessiesFeb => _sessiesFeb;
        public Link LinkGoogle { get; set; }
        public Video VideoYoutube { get; set; }
        public Video Video { get; set; }
        public Afbeelding Afbeelding { get; set; }
        public Document Excel { get; set; }
        public Document Zip { get; set; }
        public Document Word { get; set; }
        public Document Powerpoint { get; set; }
        public Document Pdf { get; set; }
        public Gebruiker Gebruiker { get; set; }
        #endregion

        public DummyApplicationDbContext()
        {
            Sessie1 = new Sessie("sessie1", new DateTime(2020, 2, 20, 14, 0, 0), new DateTime(2020, 2, 20, 15, 0, 0), false, 20, 0, "GSCHB4.026", new Verantwoordelijke(), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            Sessie2 = new Sessie("sessie2", new DateTime(2020, 2, 21, 10, 30, 0), new DateTime(2020, 2, 21, 12, 30, 0), false, 10, 0, "GSCHB4.026", new Verantwoordelijke());
            Sessie3 = new Sessie("sessie3", new DateTime(2020, 2, 22, 16, 0, 0), new DateTime(2020, 2, 22, 17, 0, 0), true, 30, 0, "GSCHB4.026", new Verantwoordelijke(), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            Sessie4 = new Sessie("sessie4", new DateTime(2020, 2, 19, 14, 0, 0), new DateTime(2020, 2, 19, 15, 0, 0), false, 20, 0, "GSCHB4.026", new Verantwoordelijke());
            Sessie5 = new Sessie("sessie5", new DateTime(2020, 3, 19, 14, 0, 0), new DateTime(2020, 2, 19, 15, 0, 0), false, 20, 0, "GSCHB4.026", new Verantwoordelijke(), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");

            _sessies = new List<Sessie> { Sessie1, Sessie2, Sessie3, Sessie4, Sessie5 };
            _sessiesFeb = new List<Sessie> { Sessie1, Sessie2, Sessie3, Sessie4};

            this.LinkGoogle = new Link("https://www.google.be/",
               "Klik hier om naar google te gaan", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Link);

            this.VideoYoutube = new Video("https://www.youtube.com/embed/1Rcf8-yk6_o",
                    "Youtbe Linux", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.YoutubeVideo);
            this.Video = new Video("test.mp4","test.mp4", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Video);

            this.Afbeelding = new Afbeelding("test.jpg",
                "test.jpg", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Afbeelding);

            this.Word= new Document("word_doc.docx", "Word document", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Word);
            this.Excel= new Document("excel_doc.xlsx", "Excel document", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Excel);
            this.Zip= new Document("zip_map.zip", "Gezipte map", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Zip);
            this.Powerpoint= new Document("powerpoint_doc.docx", "Powerpoint document", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Powerpoint);
            this.Pdf= new Document("pdf_doc.docx", "Pdf document", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Pdf);

            this.Gebruiker = new Gebruiker("test12345", "voornaam", "achternaam", "voornaam.achternaam@student.hogent.be", StatusType.Actief);



        }

    }
}
