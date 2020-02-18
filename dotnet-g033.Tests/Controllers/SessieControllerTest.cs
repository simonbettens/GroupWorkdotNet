using dotnet_g033.Controllers;
using dotnet_g033.Models.Domain;
using dotnet_g033.Tests.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_g033.Tests.Controllers
{
    
   
    public class SessieControllerTest
    {
        private readonly DummyApplicationDbContext _dummyContext;
        private readonly SessieController _sessieController;
        private readonly Mock<ISessieRepository> _mockSessieRepository;
        private readonly int _maandJan = 1;
        private readonly int _maandFeb = 2;
        private readonly int _huidigeMaand;

        public SessieControllerTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            _mockSessieRepository = new Mock<ISessieRepository>();
            _sessieController = new SessieController(_mockSessieRepository.Object)
            {
                TempData = new Mock<ITempDataDictionary>().Object
            };
            _huidigeMaand = DateTime.Now.Month;
        }

        #region Index
        [Fact]
        public void IndexGeeftLijstTerugMetEnkelSessiesVanDeMaandFebruari() {
            _mockSessieRepository.Setup(s => s.GetByMaand(_maandFeb)).Returns(_dummyContext.SessiesFeb);

            var result = Assert.IsType<ViewResult>(_sessieController.Index(_maandFeb));
            List<Sessie> sessies = Assert.IsType<List<Sessie>>(result.Model);
            var maanden = Assert.IsType<SelectList>(result.ViewData["Maanden"]);
            Assert.Equal(_maandFeb.ToString(), maanden.SelectedValue.ToString());
            Assert.Equal(4, sessies.Count);
        }
        [Fact]
        public void IndexGeeftLijstTerugMetEnkelSessiesVanDeHuidigeMaand()
        {
            _mockSessieRepository.Setup(s => s.GetByMaand(0)).Returns(_dummyContext.SessiesFeb);
            var result = Assert.IsType<ViewResult>(_sessieController.Index(0));
            List<Sessie> sessies = Assert.IsType<List<Sessie>>(result.Model);
            var maanden = Assert.IsType<SelectList>(result.ViewData["Maanden"]);
            Assert.Equal(_huidigeMaand.ToString(), maanden.SelectedValue.ToString());
        }
        [Fact]
        public void IndexGeeftLegeLijstTerugVanMaandJanuari()
        {
            _mockSessieRepository.Setup(s => s.GetByMaand(_maandJan)).Returns(new List<Sessie>());
            var result = Assert.IsType<ViewResult>(_sessieController.Index(_maandJan));
            List<Sessie> sessies = Assert.IsType<List<Sessie>>(result.Model);
            var maanden = Assert.IsType<SelectList>(result.ViewData["Maanden"]);
            Assert.Equal(_maandJan.ToString(), maanden.SelectedValue.ToString());
            Assert.Empty(sessies);
        }

        #endregion


    }
}
