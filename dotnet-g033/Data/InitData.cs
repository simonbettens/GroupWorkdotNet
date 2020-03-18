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
                DateTime huidigetijd = DateTime.Today;

                #region Gebruikers data
                var passwordHasher = new PasswordHasher<Gebruiker>();
                Gebruiker pieter = new Gebruiker(1125302310790, "pc123456", "Pieter", "Carlier", "pieter.carlier@student.hogent.be", StatusType.Actief, GebruikerType.Gebruiker);
                Gebruiker simon = new Gebruiker(1103720665999, "sb123456", "Simon", "Bettens", "simon.bettens@student.hogent.be", StatusType.Actief, GebruikerType.Gebruiker);
                Gebruiker ruben = new Gebruiker(1138608425471, "rn123456", "Ruben", "Naudts", "ruben.naudts@student.hogent.be", StatusType.Actief, GebruikerType.Gebruiker);
                Gebruiker aaron = new Gebruiker(1101056340993, "as123456", "Aaron", "Sys", "aaron.sys@student.hogent.be", StatusType.Actief, GebruikerType.Gebruiker);
                Verantwoordelijke admin = new Verantwoordelijke(1103720666020, "hdw123456", "Harm", "De Weirdt", "harm.deweirdt@hogent.be", StatusType.Actief, GebruikerType.HoofdVerantwoordelijke);
                Verantwoordelijke verantwoordelijke = new Verantwoordelijke(1103720666030, "sbv123456", "Simon", "Bettens", "simon.bettens@student.hogent.be", StatusType.Actief, GebruikerType.Verantwoordelijke);
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
                Sessie sessie1 = new Sessie("sessie1", huidigetijd.AddDays(1), huidigetijd.AddDays(1).AddHours(1), false, 20, "GSCHB4.026", admin, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", true);
                Sessie sessie2 = new Sessie("sessie2", huidigetijd.AddDays(2), huidigetijd.AddDays(2).AddHours(1), false, 10, "GSCHB4.026", verantwoordelijke, staatOpen: false);
                Sessie sessie3 = new Sessie("sessie3", huidigetijd.AddDays(3), huidigetijd.AddDays(3).AddHours(1), false, 30, "GSCHB4.026", admin, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
                Sessie sessie4 = new Sessie("sessie4", huidigetijd.AddDays(4), huidigetijd.AddDays(4).AddHours(1), false, 20, "GSCHB4.026", admin);
                Sessie sessie5 = new Sessie("sessie5", huidigetijd.AddMonths(1), huidigetijd.AddMonths(1).AddHours(1), false, 20, "GSCHB4.026", admin, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
                Sessie geslotenSessie1 = new Sessie("geslotenSessie1", new DateTime(2020, 2, 20, 14, 0, 0), new DateTime(2020, 2, 20, 15, 0, 0), true, 20, "GSCHB4.026", admin, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
                Sessie geslotenSessie2 = new Sessie("geslotenSessie2", new DateTime(2020, 2, 21, 14, 0, 0), new DateTime(2020, 2, 21, 15, 0, 0), true, 20, "GSCHB4.026", verantwoordelijke, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
                Sessie gestartSessie1 = new Sessie("gestartSessie1", huidigetijd, huidigetijd.AddMinutes(45), false, 20, "GSCHB4.026", admin, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");

                admin.voegSessieToe(sessie1);
                verantwoordelijke.voegSessieToe(sessie2);
                admin.voegSessieToe(sessie3);
                admin.voegSessieToe(sessie4);
                admin.voegSessieToe(sessie5);
                admin.voegSessieToe(geslotenSessie1);
                verantwoordelijke.voegSessieToe(geslotenSessie2);
                admin.voegSessieToe(gestartSessie1);

                sessie1.SchrijfGebruikerIn(new SessieGebruiker(sessie1, simon), simon);
                sessie1.SchrijfGebruikerIn(new SessieGebruiker(sessie1, pieter), pieter);

                Sessie[] sessies = { sessie1, sessie2, sessie3, sessie4, sessie5, geslotenSessie1, geslotenSessie2, gestartSessie1 };
                _dbContext.Sessie.AddRange(sessies);
                _dbContext.SaveChanges();
                #endregion

                #region Aankondingen
                Aankondiging algemeneAankonding1 = new Aankondiging(huidigetijd,"Dit is de eerste algemene aankondiging met lage prioriteit",admin,AankondigingPrioriteit.Laag);
                Aankondiging algemeneAankonding2 = new Aankondiging(huidigetijd,"Dit is de tweede algemene aankondiging met lage prioriteit", admin, AankondigingPrioriteit.Laag);
                Aankondiging algemeneAankonding3 = new Aankondiging(huidigetijd,"Dit is de eerst algemene aankondiging met hoge prioriteit", admin, AankondigingPrioriteit.Hoog);
                Aankondiging algemeneAankonding4 = new Aankondiging(huidigetijd,"Dit is de tweede algemene aankondiging met hoge prioriteit", admin, AankondigingPrioriteit.Hoog);

                SessieAankondiging sessieAankonding1 = new SessieAankondiging(huidigetijd, "Dit is een aankondiging voor sessie 1 met een lage prioriteit", admin,sessie1 ,AankondigingPrioriteit.Laag); 
                SessieAankondiging sessieAankonding2 = new SessieAankondiging(huidigetijd, "Dit is een aankondiging voor sessie 1 met een hoge prioriteit", admin, sessie1, AankondigingPrioriteit.Hoog);
                SessieAankondiging sessieAankonding3 = new SessieAankondiging(huidigetijd, "Dit is een aankondiging voor sessie 1 met een laag prioriteit", admin, sessie1, AankondigingPrioriteit.Laag);
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


            }
            
            
        }
    }
}
