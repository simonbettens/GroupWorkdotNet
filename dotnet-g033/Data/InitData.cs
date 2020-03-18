using dotnet_g033.Models.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;

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
                DateTime huidigetijd = DateTime.Now;

                #region Gebruikers data
                var passwordHasher = new PasswordHasher<Gebruiker>();
                Gebruiker pieter = new Gebruiker(1125302310790, "pc123456", "Pieter", "Carlier", "pieter.carlier@student.hogent.be", StatusType.Actief, GebruikerType.Gebruiker);
                Gebruiker simon = new Gebruiker(1103720665999, "sb123456", "Simon", "Bettens", "simon.bettens@student.hogent.be", StatusType.Actief, GebruikerType.Gebruiker);
                Gebruiker ruben = new Gebruiker(1138608425471, "rn123456", "Ruben", "Naudts", "ruben.naudts@student.hogent.be", StatusType.Actief, GebruikerType.Gebruiker);
                Gebruiker aaron = new Gebruiker(1101056340993, "as123456", "Aaron", "Sys", "aaron.sys@student.hogent.be", StatusType.Actief, GebruikerType.Gebruiker);
                Verantwoordelijke admin = new Verantwoordelijke(1103720666020, "hdw123456", "Harm", "De Weirdt", "harm.deweirdt@hogent.be", StatusType.Actief, GebruikerType.HoofdVerantwoordelijke);
                Verantwoordelijke verantwoordelijke = new Verantwoordelijke(1103720666030, "sbv123456", "Simon", "Bettens", "simon.bettens@student.hogent.be", StatusType.Actief, GebruikerType.Verantwoordelijke);
                pieter.EmailConfirmed = true;
                simon.EmailConfirmed = true;
                ruben.EmailConfirmed = true;
                aaron.EmailConfirmed = true;
                admin.EmailConfirmed = true;
                verantwoordelijke.EmailConfirmed = true;
                pieter.PasswordHash = passwordHasher.HashPassword(pieter, "koekjes");
                simon.PasswordHash = passwordHasher.HashPassword(simon, "appeltjes");
                ruben.PasswordHash = passwordHasher.HashPassword(ruben, "peertjes");
                aaron.PasswordHash = passwordHasher.HashPassword(aaron, "snoepjes");
                admin.PasswordHash = passwordHasher.HashPassword(admin, "adminpass");
                verantwoordelijke.PasswordHash = passwordHasher.HashPassword(verantwoordelijke, "appeltjes");
                pieter.SecurityStamp = Guid.NewGuid().ToString();
                simon.SecurityStamp = Guid.NewGuid().ToString();
                aaron.SecurityStamp = Guid.NewGuid().ToString();
                ruben.SecurityStamp = Guid.NewGuid().ToString();
                admin.SecurityStamp = Guid.NewGuid().ToString();
                verantwoordelijke.SecurityStamp = Guid.NewGuid().ToString();

                Gebruiker[] gebruikers = { pieter, simon, aaron, ruben, admin, verantwoordelijke };
                _dbContext.AddRange(gebruikers);
                _dbContext.SaveChanges();
                #endregion

                #region Sessies
                Sessie sessie1 = new Sessie(
                    "The Three Laws of TDD (featuring Kotlin)", 
                    new DateTime(2020, 3, 20, 12, 30, 0),
                    new DateTime(2020, 3, 20, 13, 30, 0), 
                    false, 
                    20, 
                    "GSCHB4.026", 
                    admin,
                    "Testen is moeilijk aan te brengen tijdens je opleiding want je komt toch niet vaak terug op oude code omdat de \"klant\" aanpassing wilt. Maar iedereen heeft al veel tijd verloren omdat er bugs waren, of omdat de code niet goed te lezen was. \n Maar Uncle Bob is terug, en deze keer legt hij de drie wetten van Test - Driven Development uit, en toont ze ook in actie. Dit zijn de drie regels:\n 1.You are not allowed to write any production code unless it is to make a failing unit test pass. \n 2.You are not allowed to write any more of a unit test than is sufficient to fail; and compilation failures are failures. \n 3.You are not allowed to write any more production code than is sufficient to pass the one failing unit test. \n Door deze drie regels te volgen garandeer je dat je code altijd doet wat ze moet doen! Als je code bijschrijft of aanpast kan je altijd vertrouwen op je tests.", 
                    false);
                
                Sessie sessie2 = new Sessie(
                    "Life is terrible: let's talk about the web",
                    new DateTime(2020, 3, 26, 12, 30, 0),
                    new DateTime(2020, 3, 26, 13, 20, 0),
                    false, 
                    10, 
                    "GSCHB4.026", 
                    verantwoordelijke, 
                    staatOpen: false);

                Sessie sessie3 = new Sessie(
                    "TDD: Where did it all go wrong?",
                    new DateTime(2020, 4, 2, 12, 30, 0),
                    new DateTime(2020, 4, 2, 13, 30, 0),
                    false,
                    30,
                    "GSCHB4.026",
                    admin,
                    "In Ontwerpen 1 leerde je al over het testen van software, en hoe TDD vitaal is voor het afleveren van werkende software. En in de volgende semesters bleef die focus op het schrijven van testen aanwezig. Maar moet die focus op TDD er wel zo sterk zijn ? Is wat nuance niet aan de orde ? Ian Cooper brengt in deze talk een duidelijk antwoord op deze vraag.Hij heeft al meer dan 20 jaar ervaring en heeft vooral gewerkt aan de architectuur van grote.NET - projecten.");


                Sessie sessie4 = new Sessie(
                    "De weg naar de Cloud",
                    new DateTime(2020, 3, 5, 12, 30, 0),
                    new DateTime(2020, 3, 5, 12, 30, 0),
                    true, 
                    20, 
                    "GSCHB4.026", 
                    admin);
                
                Sessie sessie5 = new Sessie(
                    "Improving Security Is Possible?",
                    new DateTime(2020, 3, 12, 12, 30, 0),
                    new DateTime(2020, 3, 12, 12, 30, 0),
                    true, 
                    20, 
                    "GSCHB4.026", 
                    admin,
                    "In deze talk geeft James Mickens van Harvard University zijn ongezouten mening over de mysteries van Machine Learning (\"The stuff is what the stuff is, brother.\") en andere \"hippe en innovatieve\" frameworks en technologieën, en hoe de focus op innovatie ervoor zorgt dat er nooit tijd is voor security.");

                Sessie bijnaGestarteSessie1 = new Sessie(
                    "Power use of Unix",
                    huidigetijd.AddMinutes(45),
                    huidigetijd.AddHours(1).AddMinutes(15),
                    false,
                    20,
                    "GSCHB4.026",
                    admin,
                    "Kennis van de commandline gecombineerd met de basis van reguliere expressies laten je toe om een hoger niveau van productiviteit te bereiken. Deze talk introduceert in een halfuur de meest bruikbare UNIX commando's om je workflow te optimaliseren.De perfecte sessie voor iedereen die wil kennismaken met de kracht van de commandline!");

                Sessie sessie6 = new Sessie(
                    "How to be a happy Developer. Now!", 
                    new DateTime(2020, 2, 21, 14, 0, 0), 
                    new DateTime(2020, 2, 21, 15, 0, 0), 
                    true, 
                    20, 
                    "GSCHB4.026", 
                    verantwoordelijke,
                    "Veel ontwikkelaars claimen dat ze van hun hobby hun beroep hebben gemaakt. \nDus, wat kunnen we doen om de huidige situatie te verbeteren ? Hoe kunnen we onszelf beter laten voelen ? Dieze talk richt zich op een aantal eenvoudig te implementeren tactieken die ieder van ons kan gebruiken vanaf morgen, waardoor ons leven een beetje makkelijker en leuker wordt: stuk voor stuk, dag na dag.");


                Sessie gestartSessie1 = new Sessie(
                    "How Netflix thinks of DevOps",
                    huidigetijd,
                    huidigetijd.AddMinutes(45),
                    false,
                    20,
                    "GSCHB4.026",
                    admin,
                    "Netflix wordt gezien al seen grote DevOps omgeving. Toch is “DevOps”niet iets waar ze veel over spreken. Als het dan toch zo’n kritisch deel is voor het succes van de organisatie, waarom horen we er niet meer over?\nNetflix ziet DevOps als het resultaat van een duidelijke bedrijfscultuur, niet als oplossing van een bepaald probleem.Alles begint bij de bedrijfscultuur, chaos is je vriend en vertrouwen is van absoluut belang.");
                


                admin.voegSessieToe(sessie1);
                verantwoordelijke.voegSessieToe(sessie2);
                admin.voegSessieToe(sessie3);
                admin.voegSessieToe(sessie4);
                admin.voegSessieToe(sessie5);
                verantwoordelijke.voegSessieToe(sessie6);
                admin.voegSessieToe(gestartSessie1);
                admin.voegSessieToe(bijnaGestarteSessie1);

                sessie1.SchrijfGebruikerIn(new SessieGebruiker(sessie1, simon), simon);
                sessie1.SchrijfGebruikerIn(new SessieGebruiker(sessie1, pieter), pieter);

                Sessie[] sessies = { sessie1, sessie2, sessie3, sessie4, sessie5, sessie6, gestartSessie1, bijnaGestarteSessie1 };
                _dbContext.Sessie.AddRange(sessies);
                _dbContext.SaveChanges();
                #endregion

                #region Aankondingen
                Aankondiging algemeneAankonding1 = new Aankondiging(new DateTime(2020, 3, 17, 15, 0, 0), "Studenten met interesse kunnen altijd een mailtje sturen en dan zend ik de filmpjes van de afgelaste sessies door",admin,AankondigingPrioriteit.Laag);
                Aankondiging algemeneAankonding2 = new Aankondiging(huidigetijd,"Bedankt aan alle studenten die feedback hebben gegeven op de sessies, deze komen goed van pas bij het kiezen van de volgende", admin, AankondigingPrioriteit.Laag);
                Aankondiging algemeneAankonding3 = new Aankondiging(huidigetijd,"Wegens de huidige coronamaatregelen worden hierbij alle sessies afgelast.", admin, AankondigingPrioriteit.Hoog);
                Aankondiging algemeneAankonding4 = new Aankondiging(huidigetijd,"Het IT-Lab zal niet open zijn tot minstens 5 april wegens de landelijke coronamaatregelen", admin, AankondigingPrioriteit.Hoog);

                SessieAankondiging sessieAankonding1 = new SessieAankondiging(huidigetijd, "Studenten die nog steeds interesse vertonen kunnen mij een mailtje sturen, ik zal het filmpje van de sessie doorsturen", admin,sessie1 ,AankondigingPrioriteit.Laag); 
                SessieAankondiging sessieAankonding2 = new SessieAankondiging(huidigetijd, "Deze sessie zal afgelast worden door de huidige coronamaatregelen", admin, sessie1, AankondigingPrioriteit.Hoog);
                SessieAankondiging sessieAankonding3 = new SessieAankondiging(huidigetijd, "Deze sessie zal afgelast worden door de huidige coronamaatregelen", admin, sessie2, AankondigingPrioriteit.Hoog);
                sessieAankonding1.VoegAankondingToeAanSessie();
                sessieAankonding2.VoegAankondingToeAanSessie();
                sessieAankonding3.VoegAankondingToeAanSessie();

                Aankondiging[] aankondingen = { algemeneAankonding1, algemeneAankonding2, algemeneAankonding3, algemeneAankonding4, 
                    sessieAankonding1, sessieAankonding2 };
                _dbContext.AddRange(aankondingen);
                _dbContext.SaveChanges();
                #endregion

                #region Media
                Link link1 = new Link("https://www.google.be/", "Klik hier om naar google te gaan", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Link);

                sessie1.VoegMediaToe(link1);
                _dbContext.Link.Add(link1);
                _dbContext.SaveChanges();

                Video video1 = new Video("https://www.youtube.com/embed/1Rcf8-yk6_o", "Youtbe Linux", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.YoutubeVideo);
                Video video2 = new Video($"/videos/testVideo.mp4", "Video binary", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Video);

                sessie1.VoegMediaToe(video1);
                sessie1.VoegMediaToe(video2);
                Video[] videos = { video1, video2 };
                _dbContext.Video.AddRange(videos);
                _dbContext.SaveChanges();

                Afbeelding afbeelding1 = new Afbeelding("/images/StockFoto1.jpg", "StockFoto1", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Afbeelding);
                Afbeelding afbeelding2 = new Afbeelding("/images/StockFoto2.jpg", "StockFoto2", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Afbeelding);
                Afbeelding afbeelding3 = new Afbeelding("/images/StockFoto3.jpg", "StockFoto3", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Afbeelding);
                Afbeelding afbeelding4 = new Afbeelding("/images/StockFoto1.jpg", "StockFoto1", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Afbeelding);

                sessie1.VoegMediaToe(afbeelding1);
                sessie1.VoegMediaToe(afbeelding2);
                sessie1.VoegMediaToe(afbeelding3);
                sessie2.VoegMediaToe(afbeelding4);
                Afbeelding[] afbeeldingen = { afbeelding1, afbeelding2, afbeelding3, afbeelding4 };
                _dbContext.Afbeelding.AddRange(afbeeldingen);
                _dbContext.SaveChanges();

                Document doc1 = new Document("/documents/Test_document_itlab_sessie.docx", "Word document", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Word);
                Document doc2 = new Document("/documents/Test_document_itlab_sessie.pdf", "Pdf document", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Pdf);
                Document doc3 = new Document("/documents/Test_excel.xlsx", "Excel document", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Excel);
                Document doc4 = new Document("/documents/Test_powerpoint.pptx", "Powerpoint document", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Powerpoint);
                Document doc5 = new Document("/documents/TestDocumenten.zip", "Gezipte map", new DateTime(2020, 2, 20, 14, 0, 0), MediaType.Zip);

                sessie1.VoegMediaToe(doc1);
                sessie1.VoegMediaToe(doc2);
                sessie1.VoegMediaToe(doc3);
                sessie1.VoegMediaToe(doc4);
                sessie1.VoegMediaToe(doc5);
                Document[] documenten = { doc1, doc2, doc3, doc4, doc5 };
                _dbContext.Document.AddRange(documenten);
                _dbContext.SaveChanges();
                #endregion

                #region Feedback
                Feedback feedback1 = new Feedback(3, DateTime.Now, "Pieter", "Carlier", "pc123456", "Zeer toffe sessie!!!");
                Feedback feedback2 = new Feedback(1, DateTime.Now, "Aaron", "Sys", "as123456", "HEB HIER NIETS UIT GELEERD, SLECHT");
                Feedback feedback3 = new Feedback(5, DateTime.Now, "Simon", "Bettens", "sb123456", "zeer tof en leerrijk, spreker was ook zeer enthousiast :)");
                Feedback[] feedback = { feedback1, feedback2, feedback3 };

                sessie5.VoegFeedbackToe(feedback1);
                sessie5.VoegFeedbackToe(feedback2);
                sessie4.VoegFeedbackToe(feedback3);
                _dbContext.Feedback.AddRange(feedback);
                _dbContext.SaveChanges(); 
                #endregion
            }
            
            
        }
    }
}
