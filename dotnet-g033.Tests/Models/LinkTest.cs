using dotnet_g033.Models.Domain;
using dotnet_g033.Tests.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_g033.Tests.Models
{
    public class LinkTest
    {
        public Link Link { get; set; }
        private readonly DummyApplicationDbContext _dummyContext;
        public LinkTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            this.Link = _dummyContext.LinkGoogle;
        }
    }
}
