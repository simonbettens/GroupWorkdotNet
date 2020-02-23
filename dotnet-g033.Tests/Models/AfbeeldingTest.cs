﻿using dotnet_g033.Models.Domain;
using dotnet_g033.Tests.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_g033.Tests.Models
{
    public class AfbeeldingTest
    {
        public Afbeelding Afbeelding { get; set; }
        private readonly DummyApplicationDbContext _dummyContext;
        public AfbeeldingTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            this.Afbeelding = _dummyContext.Afbeelding;
        }
        [Fact]
        public void Display()
        {
            String uitkomst = "<a href=\"test.jpg\" target=\"_blank\">" +
                    "<img src=\"test.jpg\" alt=\"test.jpg\" style = \"width:100%\"> " +
                    "<div class=\"caption\">" +
                        "<p>test.jpg</p>" +
                    "</div>" +
                "</a>";
            Assert.Equal(uitkomst, Afbeelding.Display());
        }
        
    }
}
