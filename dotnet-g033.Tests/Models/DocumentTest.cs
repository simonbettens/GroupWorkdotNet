using dotnet_g033.Models.Domain;
using dotnet_g033.Tests.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_g033.Tests.Models
{
    public class DocumentTest
    {
        public Document Excel { get; set; }
        public Document Zip { get; set; }
        public Document Word { get; set; }
        public Document Powerpoint { get; set; }
        public Document Pdf { get; set; }
        private readonly DummyApplicationDbContext _dummyContext;
        
        public DocumentTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            this.Excel = _dummyContext.Excel;
            this.Zip = _dummyContext.Zip;
            this.Word = _dummyContext.Word;
            this.Powerpoint = _dummyContext.Powerpoint;
            this.Pdf = _dummyContext.Pdf;
        }
    }
}
