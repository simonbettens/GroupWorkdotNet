using dotnet_g033.Controllers;
using dotnet_g033.Models.Domain;
using dotnet_g033.Models.ViewModels;
using dotnet_g033.Tests.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace dotnet_g033.Tests.Controllers
{


    public class SessieControllerTest
    {
        #region Fields
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly SessieController _sessieController;
        private readonly Mock<ISessieRepository> _mockSessieRepository;
        private readonly Mock<IGebruikerRepository> _mockGebruikerRepository;
        private readonly Mock<IFeedbackRepository> _mockFeedbackRepository;
        private readonly Sessie _sessie;
        private readonly Sessie _sessie2;
        private readonly Sessie _sessie3;
        private readonly Sessie _sessie6;
        private readonly Sessie _sessie7;
        private readonly Sessie _sessie8; //gesloten & afgelopen
        private readonly int _maandJan = 1;
        private readonly int _maandFeb = 2;
        private readonly int _huidigeMaand;
        private readonly Gebruiker _gebruiker;
        private readonly Verantwoordelijke _verantwoordelijkeLeeg;
        private readonly Verantwoordelijke _verantwoordelijke;
        private readonly Verantwoordelijke _hoofdverantwoordelijke;
        private readonly Feedback _feedback;
        #endregion

        public SessieControllerTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            _mockSessieRepository = new Mock<ISessieRepository>();
            _mockGebruikerRepository = new Mock<IGebruikerRepository>();
            _mockFeedbackRepository = new Mock<IFeedbackRepository>();
            _sessieController = new SessieController(_mockSessieRepository.Object, _mockGebruikerRepository.Object, _mockFeedbackRepository.Object)
            {
                TempData = new Mock<ITempDataDictionary>().Object
            };
            _huidigeMaand = DateTime.Now.Month;
            _gebruiker = _dummyContext.Gebruiker;
            _verantwoordelijkeLeeg = _dummyContext.VerantwoordelijkeLeeg;
            _verantwoordelijke = _dummyContext.Verantwoordelijke;
            _hoofdverantwoordelijke = _dummyContext.Hoofdverantwoordelijke;
            _sessie = _dummyContext.Sessie1;
            _sessie2 = _dummyContext.Sessie2;
            _sessie3 = _dummyContext.Sessie3;
            _sessie6 = _dummyContext.Sessie6;
            _sessie7 = _dummyContext.Sessie7;
            _sessie8 = _dummyContext.Sessie8;

            _feedback = _dummyContext.Feedback;
        }

        #region Index
        [Fact]
        public void IndexGeeftLijstTerugMetEnkelSessiesVanDeMaandFebruari()
        {
            _mockSessieRepository.Setup(s => s.GetByMaand(_maandFeb)).Returns(_dummyContext.SessiesFeb);

            var result = Assert.IsType<ViewResult>(_sessieController.Index(_gebruiker, _maandFeb));
            SessieIndexViewmodel sessieViewModel = Assert.IsType<SessieIndexViewmodel>(result.Model);
            var maanden = Assert.IsType<SelectList>(result.ViewData["Maanden"]);
            Assert.Equal(_maandFeb.ToString(), maanden.SelectedValue.ToString());
            Assert.Equal(4, sessieViewModel.Sessies.Count());
        }
        [Fact]
        public void IndexGeeftLijstTerugMetEnkelSessiesVanDeHuidigeMaand()
        {
            _mockSessieRepository.Setup(s => s.GetByMaand(0)).Returns(_dummyContext.SessiesFeb);
            var result = Assert.IsType<ViewResult>(_sessieController.Index(_gebruiker, 0));
            SessieIndexViewmodel sessieViewModel = Assert.IsType<SessieIndexViewmodel>(result.Model);
            var maanden = Assert.IsType<SelectList>(result.ViewData["Maanden"]);
            Assert.Equal(_huidigeMaand.ToString(), maanden.SelectedValue.ToString());
        }
        [Fact]
        public void IndexGeeftLegeLijstTerugVanMaandJanuari()
        {
            _mockSessieRepository.Setup(s => s.GetByMaand(_maandJan)).Returns(new List<Sessie>());
            var result = Assert.IsType<ViewResult>(_sessieController.Index(_gebruiker, _maandJan));
            SessieIndexViewmodel sessieViewModel = Assert.IsType<SessieIndexViewmodel>(result.Model);
            var maanden = Assert.IsType<SelectList>(result.ViewData["Maanden"]);
            Assert.Equal(_maandJan.ToString(), maanden.SelectedValue.ToString());
            Assert.Empty(sessieViewModel.Sessies);
        }



        #endregion

        #region Details
        [Fact]
        public void DetailsTest_KanSessieNietVinden()
        {

            _mockSessieRepository.Setup(s => s.GetById(1)).Returns((Sessie)null);
            Assert.IsType<RedirectToActionResult>(_sessieController.Details(1, _gebruiker));
        }
        [Fact]
        public void DetailsTest_KanSessieVinden()
        {
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns(_sessie);
            var result = Assert.IsType<ViewResult>(_sessieController.Details(1, _gebruiker));
            SessieDetailsViewModel sessieDetails = Assert.IsType<SessieDetailsViewModel>(result.Model);
        }

        [Fact]
        public void Details_LegalId_GeeftSessieTerug()
        {
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns(_dummyContext.Sessie1);
            var result = Assert.IsType<ViewResult>(_sessieController.Details(1, _gebruiker));
            SessieDetailsViewModel sdvm = Assert.IsType<SessieDetailsViewModel>(result.Model);
            var ingeschreven = Assert.IsType<bool>(result.ViewData["IsIngeschreven"]);
            if (ingeschreven)
            {
                var aanwezig = Assert.IsType<bool>(result.ViewData["IsAanwezig"]);
            }
        }
        #endregion

        #region Inscrhijven
        [Fact]
        public void Inschrijven_KanSessieNietVinden()
        {
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns((Sessie)null);

            _sessieController.InSchrijven(1, _gebruiker);
            Assert.False(_sessie.GebruikerIsIngeschreven(_gebruiker));
        }
        [Fact]
        public void Inschrijven_GebruikerNietIngelogd_SchrijftNietIn()
        {
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns(_sessie);
            _sessieController.InSchrijven(1, (Gebruiker)null);
            Assert.False(_sessie.GebruikerIsIngeschreven(_gebruiker));
        }

        [Fact]
        public void Inschrijven_KanSessieVinden()
        {
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns(_sessie);
            var result = Assert.IsType<RedirectToActionResult>(_sessieController.InSchrijven(1, _gebruiker));
            Assert.True(_sessie.GebruikerIsIngeschreven(_gebruiker));
        }
        #endregion

        #region Uitschrijven
        [Fact]
        public void Uitschrijven_SessieIdIsOngeldig_SchrijftNietUit()
        {
            _sessie.SchrijfGebruikerIn(new SessieGebruiker(_sessie, _gebruiker), _gebruiker);
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns((Sessie)null);
            var result = Assert.IsType<RedirectToActionResult>(_sessieController.Uitschrijven(1, _gebruiker));
            Assert.True(_sessie.GebruikerIsIngeschreven(_gebruiker));
        }

        [Fact]
        public void Uitschrijven_GebruikerNietIngelogd_SchrijftNietUit()
        {
            _sessie.SchrijfGebruikerIn(new SessieGebruiker(_sessie, _gebruiker), _gebruiker);
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns(_sessie);
            var result = Assert.IsType<RedirectToActionResult>(_sessieController.Uitschrijven(1, (Gebruiker)null));
            Assert.True(_sessie.GebruikerIsIngeschreven(_gebruiker));
        }

        [Fact]
        public void Uitschrijven_GeldigeVoorwaarden_GebruikerUitgeschreven()
        {
            _sessie.SchrijfGebruikerIn(new SessieGebruiker(_sessie, _gebruiker), _gebruiker);
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns(_sessie);
            _sessieController.Uitschrijven(1, _gebruiker);
            Assert.False(_sessie.GebruikerIsIngeschreven(_gebruiker));
        }

        [Fact]
        public void Uitschrijven_SessieIsAlVoorbij_SchrijftNietUit()
        {
            _sessie2.SchrijfGebruikerIn(new SessieGebruiker(_sessie2, _gebruiker), _gebruiker);
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns(_sessie2);
            _sessieController.Uitschrijven(1, _gebruiker);
            Assert.True(_sessie2.GebruikerIsIngeschreven(_gebruiker));
        }
        #endregion

        #region Aanwezig Stellen

        [Fact]
        public void AanwezigStellen_GeldigeVoorwaarden_GebruikerAanwezigGezet()
        {
            _sessie.SchrijfGebruikerIn(new SessieGebruiker(_sessie, _gebruiker), _gebruiker);
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns(_sessie);
            _sessieController.AanwezigStellen(1, _gebruiker);
            Assert.True(_sessie.GeefSessieGebruiker(_gebruiker).Aanwezig);
        }

        [Fact]
        public void AanwezigStellen_GebruikerNietAangemeld_GebruikerNietAanwezigGezet()
        {
            _sessie.SchrijfGebruikerIn(new SessieGebruiker(_sessie, _gebruiker), _gebruiker);
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns(_sessie);
            _sessieController.AanwezigStellen(1, (Gebruiker)null);
            Assert.False(_sessie.GeefSessieGebruiker(_gebruiker).Aanwezig);
        }

        [Fact]
        public void AanwezigStellen_OngeldigSessieId_GebruikerNietAanwezigGezet()
        {
            _sessie.SchrijfGebruikerIn(new SessieGebruiker(_sessie, _gebruiker), _gebruiker);
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns((Sessie)null);
            _sessieController.AanwezigStellen(1, _gebruiker);
            Assert.False(_sessie.GeefSessieGebruiker(_gebruiker).Aanwezig);
        }

        [Fact]
        public void AanwezigStellen_GebruikerNietIngeschreven_GebruikerNietAanwezigGezet()
        {
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns(_sessie);
            _sessieController.AanwezigStellen(1, _gebruiker);
            Assert.Null(_sessie.GeefSessieGebruiker(_gebruiker));
        }
        #endregion

        #region Openzetten
        [Fact]
        public void Sessie_Openzetten_KanGeslotenSessieNietVinden()
        {
            _mockSessieRepository.Setup(s => s.GetSessieVerantwoordelijkeNogTeOpenen(_verantwoordelijkeLeeg, 3)).Returns(new List<Sessie>());
            var result = Assert.IsType<ViewResult>(_sessieController.OpenzettenIndex(_verantwoordelijkeLeeg));
            SessieIndexViewmodel sessieOpenZetten = Assert.IsType<SessieIndexViewmodel>(result.Model);
            Assert.Empty(sessieOpenZetten.Sessies);
        }
        [Fact]
        public void Sessie_Openzetten_KanOpenSessieVinden()
        {
            _mockSessieRepository.Setup(s => s.GetSessieVerantwoordelijkeNogTeOpenen(_verantwoordelijke, 3)).Returns(new List<Sessie>() { _sessie2 });
            var result = Assert.IsType<ViewResult>(_sessieController.OpenzettenIndex(_verantwoordelijke));
            SessieIndexViewmodel sessieOpenZetten = Assert.IsType<SessieIndexViewmodel>(result.Model);
            Assert.Contains(_sessie2, sessieOpenZetten.Sessies);
        }
        [Fact]
        public void Sessie_Openzetten_OpenzettenVanSessie()
        {
            _mockSessieRepository.Setup(s => s.GetById(6)).Returns(_sessie6);
            _sessieController.VeranderStaatOpen(6);
            Assert.True(_sessie6.StaatOpen);
        }
        [Fact]
        public void Sessie_Openzetten_SluitenVanSessie()
        {
            _mockSessieRepository.Setup(s => s.GetById(7)).Returns(_sessie7);
            _sessieController.VeranderStaatOpen(7);
            Assert.False(_sessie7.StaatOpen);
        }
        [Fact]
        public void SluitSessieDefentief() {
            _mockSessieRepository.Setup(s => s.GetById(7)).Returns(_sessie7);
            _sessieController.SluitSessie(7);
            Assert.False(_sessie7.StaatOpen);
            Assert.True(_sessie7.Gesloten);
        }
        #endregion

        #region Feedback

        [Fact]
        public void Feedback_nietAangemeld()
        {
            _sessie3.SchrijfGebruikerIn(new SessieGebruiker(_sessie3, _gebruiker), _gebruiker);
            _mockSessieRepository.Setup(s => s.GetById(3)).Returns(_sessie3);
            _sessieController.AanwezigStellen(3, _gebruiker);
            _sessie3.VoegFeedbackToe(_feedback);
            FeedbackModel model = new FeedbackModel();
            model.AantalSterren = 2;
            model.Comment = "DUMMY COMMENT";
            model.SessieId = 3;
            Assert.IsType<RedirectToActionResult>(_sessieController.VoegFeedbackToe(model, _gebruiker));
        }
        [Fact]
        public void Feedback_nietIngeschreven()
        {
            _mockSessieRepository.Setup(s => s.GetById(3)).Returns(_sessie3);
            _sessie3.VoegFeedbackToe(_feedback);
            FeedbackModel model = new FeedbackModel();
            model.AantalSterren = 2;
            model.Comment = "DUMMY COMMENT";
            model.SessieId = 3;
            Assert.Empty(_sessie3.GebruikersIngeschreven);
            Assert.IsType<RedirectToActionResult>(_sessieController.VoegFeedbackToe(model, _gebruiker));
        }
        [Fact]
        public void Feedback_NegatieveStarRating()
        {
            _sessie2.SchrijfGebruikerIn(new SessieGebruiker(_sessie2, _gebruiker), _gebruiker);
            _mockSessieRepository.Setup(s => s.GetById(2)).Returns(_sessie2);
            _sessie2.StelGebruikerAanwezigBevestigd(_sessie2.GeefSessieGebruiker(_gebruiker));
            FeedbackModel model = new FeedbackModel();
            model.AantalSterren = -4;
            model.Comment = "DUMMY COMMENT";
            model.SessieId = 2;
            Assert.IsType<RedirectToActionResult>(_sessieController.VoegFeedbackToe(model, _gebruiker));
        }
        [Fact]
        public void Feedback_TeGrootteStarRating()
        {
            _sessie2.SchrijfGebruikerIn(new SessieGebruiker(_sessie2, _gebruiker), _gebruiker);
            _mockSessieRepository.Setup(s => s.GetById(2)).Returns(_sessie2);
            _sessie2.StelGebruikerAanwezigBevestigd(_sessie2.GeefSessieGebruiker(_gebruiker));
            FeedbackModel model = new FeedbackModel();
            model.AantalSterren =50;
            model.Comment = "DUMMY COMMENT";
            model.SessieId = 2;
            Assert.IsType<RedirectToActionResult>(_sessieController.VoegFeedbackToe(model, _gebruiker));
        }
        [Fact]
        public void Feedback_CorrecteStarRating()
        {
            _sessie2.SchrijfGebruikerIn(new SessieGebruiker(_sessie2, _gebruiker), _gebruiker);
            _mockSessieRepository.Setup(s => s.GetById(2)).Returns(_sessie2);
            _sessie2.StelGebruikerAanwezigBevestigd(_sessie2.GeefSessieGebruiker(_gebruiker));
            FeedbackModel model = new FeedbackModel();
            model.AantalSterren = 5;
            model.Comment = "DUMMY COMMENT";
            model.SessieId = 2;
            Assert.IsType<RedirectToActionResult>(_sessieController.VoegFeedbackToe(model, _gebruiker));
        }
        [Fact]
        public void Feedback_TeGrootteComment()
        {
            _sessie2.SchrijfGebruikerIn(new SessieGebruiker(_sessie2, _gebruiker), _gebruiker);
            _mockSessieRepository.Setup(s => s.GetById(2)).Returns(_sessie2);
            _sessie2.StelGebruikerAanwezigBevestigd(_sessie2.GeefSessieGebruiker(_gebruiker));
            FeedbackModel model = new FeedbackModel();
            model.AantalSterren = 5;
            model.Comment = "Aenean aliquam ex ut lacinia efficitur. Integer mattis elit odio, vitae dapibus quam tempus sit amet. Quisque congue consequat pellentesque. Aenean ullamcorper purus sodales egestas pharetra. Ut id blandit leo, non iaculis tellus. Proin tortor ex, tempus sed nisl vitae, semper bibendum metus. Pellentesque malesuada, nisl nec commodo hendrerit, tellus orci lacinia nunc, sed facilisis erat purus sit amet ligula. Cras et dignissim erat, sagittis sagittis ipsum. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Praesent eleifend porttitor lorem sed pharetra. Vestibulum pulvinar, nisl sit amet tristique blandit, ligula arcu hendrerit est, vel vulputate leo nisl scelerisque tortor. Fusce vestibulum in nibh tincidunt consequat."+
                "In egestas vel metus eu maximus. Vestibulum non risus vel enim rutrum accumsan.Aenean quis laoreet est. Vivamus consectetur consequat metus at mollis. Sed eget lacus eget est dignissim feugiat finibus sit amet ante.Duis condimentum nunc vel nibh vulputate dapibus.Quisque efficitur ornare enim. Quisque cursus porta elit in bibendum.Cras pellentesque leo non lectus elementum, nec condimentum nibh congue.Suspendisse ultricies nibh dictum, elementum augue scelerisque, luctus sapien.";
            model.SessieId = 2;
            _mockFeedbackRepository.Setup(f => f.SaveChanges()).Throws(new ArgumentException());
            Assert.IsType<RedirectToActionResult>(_sessieController.VoegFeedbackToe(model, _gebruiker));
        }
        [Fact]
        public void Feedback_VerwijderenDoorHoofdverantwoordelijke()
        {
            _mockSessieRepository.Setup(s => s.GetById(2)).Returns(_sessie2);
            _sessie2.VoegFeedbackToe(_feedback);
            _mockFeedbackRepository.Setup(f => f.GetByID(1)).Returns(_feedback);
          Assert.IsType<RedirectToActionResult>(_sessieController.VerwijderFeedback(2, 1, _hoofdverantwoordelijke));
        }
        [Fact]
        public void Feedback_VerwijderenDooFouteGebruiker()
        {
            _mockSessieRepository.Setup(s => s.GetById(2)).Returns(_sessie2);
            _sessie2.VoegFeedbackToe(_feedback);
            _mockFeedbackRepository.Setup(f => f.GetByID(1)).Returns(_feedback);
            Assert.IsType<RedirectToActionResult>(_sessieController.VerwijderFeedback(2, 1, _verantwoordelijke));
        }
        [Fact]
        public void Feedback_VerwijderenDoorJuisteGebruiker()
        {
            _mockSessieRepository.Setup(s => s.GetById(2)).Returns(_sessie2);
            Feedback feedback = new Feedback(2, DateTime.Now, _gebruiker.Voornaam, _gebruiker.Achternaam, _gebruiker.UserName);
            _sessie2.VoegFeedbackToe(feedback);
            _mockFeedbackRepository.Setup(f => f.GetByID(1)).Returns(feedback);
            Assert.IsType<RedirectToActionResult>(_sessieController.VerwijderFeedback(2, 1, _gebruiker));
        }
        #endregion


    }
}

