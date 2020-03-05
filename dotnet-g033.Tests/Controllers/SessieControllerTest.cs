﻿using dotnet_g033.Controllers;
using dotnet_g033.Models.Domain;
using dotnet_g033.Models.ViewModels;
using dotnet_g033.Tests.Data;
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
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly SessieController _sessieController;
        private readonly Mock<ISessieRepository> _mockSessieRepository;
        private readonly Mock<IGebruikerRepository> _mockGebruikerRepository;
        private readonly Sessie _sessie;
        private readonly Sessie _sessie2;
        private readonly int _maandJan = 1;
        private readonly int _maandFeb = 2;
        private readonly int _huidigeMaand;
        private readonly Gebruiker _gebruiker;
        private readonly Verantwoordelijke _verantwoordelijkeLeeg;
        private readonly Verantwoordelijke _verantwoordelijke;

        public SessieControllerTest() {
            _dummyContext = new DummyApplicationDbContext();
            _mockSessieRepository = new Mock<ISessieRepository>();
            _mockGebruikerRepository = new Mock<IGebruikerRepository>();
            _sessieController = new SessieController(_mockSessieRepository.Object, _mockGebruikerRepository.Object) {
                TempData = new Mock<ITempDataDictionary>().Object
            };
            _huidigeMaand = DateTime.Now.Month;
            _gebruiker = _dummyContext.Gebruiker;
            _verantwoordelijkeLeeg = _dummyContext.VerantwoordelijkeLeeg;
            _verantwoordelijke= _dummyContext.Verantwoordelijke;
            _sessie = _dummyContext.Sessie1;
            _sessie2 = _dummyContext.Sessie2;
        }

        #region Index
        [Fact]
        public void IndexGeeftLijstTerugMetEnkelSessiesVanDeMaandFebruari() {
            _mockSessieRepository.Setup(s => s.GetByMaand(_maandFeb)).Returns(_dummyContext.SessiesFeb);

            var result = Assert.IsType<ViewResult>(_sessieController.Index(_gebruiker, _maandFeb));
            SessieIndexViewmodel sessieViewModel = Assert.IsType<SessieIndexViewmodel>(result.Model);
            var maanden = Assert.IsType<SelectList>(result.ViewData["Maanden"]);
            Assert.Equal(_maandFeb.ToString(), maanden.SelectedValue.ToString());
            Assert.Equal(4, sessieViewModel.Sessies.Count());
        }
        [Fact]
        public void IndexGeeftLijstTerugMetEnkelSessiesVanDeHuidigeMaand() {
            _mockSessieRepository.Setup(s => s.GetByMaand(0)).Returns(_dummyContext.SessiesFeb);
            var result = Assert.IsType<ViewResult>(_sessieController.Index(_gebruiker, 0));
            SessieIndexViewmodel sessieViewModel = Assert.IsType<SessieIndexViewmodel>(result.Model);
            var maanden = Assert.IsType<SelectList>(result.ViewData["Maanden"]);
            Assert.Equal(_huidigeMaand.ToString(), maanden.SelectedValue.ToString());
        }
        [Fact]
        public void IndexGeeftLegeLijstTerugVanMaandJanuari() {
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
        public void DetailsTest_KanSessieNietVinden() {

            _mockSessieRepository.Setup(s => s.GetById(1)).Returns((Sessie)null);
            var result = Assert.IsType<RedirectToActionResult>(_sessieController.Details(1, _gebruiker));
        }
        [Fact]
        public void DetailsTest_KanSessieVinden() {
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns(_sessie);
            var result = Assert.IsType<ViewResult>(_sessieController.Details(1, _gebruiker));
            SessieDetailsViewModel sessieDetails = Assert.IsType<SessieDetailsViewModel>(result.Model);
        }


        [Fact]
        public void Details_LegalId_GeeftSessieTerug() {
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns(_dummyContext.Sessie1);
            var result = Assert.IsType<ViewResult>(_sessieController.Details(1, _gebruiker));
            SessieDetailsViewModel sdvm = Assert.IsType<SessieDetailsViewModel>(result.Model);
            var ingeschreven = Assert.IsType<bool>(result.ViewData["IsIngeschreven"]);
            if (ingeschreven) {
                var aanwezig = Assert.IsType<bool>(result.ViewData["IsAanwezig"]);
            }
        }
        #endregion

        #region Inscrhijven
        [Fact]
        public void Inschrijven_KanSessieNietVinden() {
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns((Sessie)null);
            var result = Assert.IsType<RedirectToActionResult>(_sessieController.InSchrijven(1, _gebruiker));
        }
        [Fact]
        public void Inschrijven_KanSessieVindenEnKanNietOpslaan() {
            _mockSessieRepository.Setup(s => s.GetById(1)).Returns(_sessie);
            _mockSessieRepository.Setup(s => s.SaveChanges()).Throws<Exception>();
            var result = Assert.IsType<RedirectToActionResult>(_sessieController.InSchrijven(1, _gebruiker));
        }


        #endregion

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

            _mockSessieRepository.Setup(s => s.GetSessieVerantwoordelijkeNogTeOpenen(_verantwoordelijke, 3)).Returns(new List<Sessie>() {_sessie2});
            var result = Assert.IsType<ViewResult>(_sessieController.OpenzettenIndex(_verantwoordelijke));
            SessieIndexViewmodel sessieOpenZetten = Assert.IsType<SessieIndexViewmodel>(result.Model);
            Assert.Contains(_sessie2, sessieOpenZetten.Sessies);

        }


    }
}
