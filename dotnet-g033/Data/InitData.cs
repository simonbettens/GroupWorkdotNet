using dotnet_g033.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Data
{
    public class InitData
    {
        private readonly ApplicationDbContext _dbContext;

        public InitData(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public void InitializeData()
        {
            
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                Sessie sessie1 = new Sessie("sessie1", new DateTime(2020, 2, 20, 14, 0, 0), new DateTime(2020, 2, 20, 15, 0, 0), false, 20, 0, "GSCHB4.026", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
                Sessie sessie2 = new Sessie("sessie2", new DateTime(2020, 2, 21, 10, 30, 0), new DateTime(2020, 2, 21, 12, 30, 0), false, 10, 0, "GSCHB4.026");
                Sessie sessie3 = new Sessie("sessie3", new DateTime(2020, 2, 22, 16, 0, 0), new DateTime(2020, 2, 22, 17, 0, 0), true, 30, 0, "GSCHB4.026", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
                Sessie sessie4 = new Sessie("sessie4", new DateTime(2020, 2, 19, 14, 0, 0), new DateTime(2020, 2, 19, 15, 0, 0), false, 20, 0, "GSCHB4.026");
                Sessie sessie5 = new Sessie("sessie5", new DateTime(2020, 3, 19, 14, 0, 0), new DateTime(2020, 2, 19, 15, 0, 0), false, 20, 0, "GSCHB4.026", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");

                Sessie[] sessies = { sessie1, sessie2, sessie3, sessie4, sessie5 };
                _dbContext.Sessie.AddRange(sessies);
                _dbContext.SaveChanges();
                Link link1 = new Link("https://www.google.be/", "Klik hier om naar google te gaan", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Link);
                sessie1.Media.VoegLinkToe(link1);
                _dbContext.Link.Add(link1);
                _dbContext.SaveChanges();

                Video video1 = new Video("https://www.youtube.com/embed/1Rcf8-yk6_o", "Youtbe Linux", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.YoutubeVideo);
                Video video2 = new Video($"/videos/testVideo.mp4", "Video binary", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Video);
                sessie1.Media.VoegVideoToe(video1);
                sessie1.Media.VoegVideoToe(video2);
                Video[] videos = { video1, video2 };
                _dbContext.Video.AddRange(videos);
                _dbContext.SaveChanges();

                Afbeelding afbeelding1 = new Afbeelding("/images/StockFoto1.jpg", "StockFoto1", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Afbeelding);
                Afbeelding afbeelding2 = new Afbeelding("/images/StockFoto2.jpg", "StockFoto2", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Afbeelding);
                Afbeelding afbeelding3 = new Afbeelding("/images/StockFoto3.jpg", "StockFoto3", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Afbeelding);
                Afbeelding afbeelding4 = new Afbeelding("/images/StockFoto1.jpg", "StockFoto1", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Afbeelding);
                sessie1.Media.VoegAfbeeldingToe(afbeelding1);
                sessie1.Media.VoegAfbeeldingToe(afbeelding2);
                sessie1.Media.VoegAfbeeldingToe(afbeelding3);
                sessie2.Media.VoegAfbeeldingToe(afbeelding4);
                Afbeelding[] afbeeldingen = { afbeelding1, afbeelding2, afbeelding3, afbeelding4 };
                _dbContext.Afbeelding.AddRange(afbeeldingen);

                Document doc1 = new Document("/documents/Test_document_itlab_sessie.docx", "Word document", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Word);
                Document doc2 = new Document("/documents/Test_document_itlab_sessie.pdf", "Pdf document", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Pdf);
                Document doc3 = new Document("/documents/Test_excel.xlsx", "Excel document", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Excel);
                Document doc4 = new Document("/documents/Test_powerpoint.pptx", "Powerpoint document", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Powerpoint);
                Document doc5 = new Document("/documents/TestDocumenten.zip", "Gezipte map", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Zip);
                sessie1.Media.VoegDocumentToe(doc1);
                sessie1.Media.VoegDocumentToe(doc2);
                sessie1.Media.VoegDocumentToe(doc3);
                sessie1.Media.VoegDocumentToe(doc4);
                sessie1.Media.VoegDocumentToe(doc5);
                Document[] documenten = { doc1, doc2, doc3, doc4, doc5 };
                _dbContext.Document.AddRange(documenten);
                _dbContext.SaveChanges();
            }
            
        }
    }
}
