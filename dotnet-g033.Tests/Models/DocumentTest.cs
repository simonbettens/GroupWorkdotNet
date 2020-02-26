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
        #region Display
        [Fact]
        public void DisplayExcelTest()
        {
            string uikomst = $"<tr>" +
                 $"<td>" +
                 $"<span class=\"iconify\" data-icon=\"ant-design:file-excel-outlined\" data-inline=\"false\"></span>" +
                 $"</td>" +
                 $"<td><a href=\"{Excel.Adress}\" target=\"_blank\">{Excel.Naam}</a></td>" +
                 $"<td>{Excel.TijdToegevoegd.ToString("ddd dd/MM/yyyy, HH:mm")}</td>" +
                 $"<tr>";
            Assert.Equal(uikomst, Excel.Display());
        }
        [Fact]
        public void DisplayZipTest()
        {
            string uikomst = $"<tr>" +
                $"<td>" +
                $"<span class=\"iconify\" data-icon=\"ant-design:file-zip-filled\" data-inline=\"false\"></span>" +
                $"</td>" +
                $"<td><a href=\"{Zip.Adress}\" target=\"_blank\">{Zip.Naam}</a></td>" +
                $"<td>{Zip.TijdToegevoegd.ToString("ddd dd/MM/yyyy, HH:mm")}</td>" +
                $"<tr>";
            Assert.Equal(uikomst, Zip.Display());
        }
        [Fact]
        public void DisplayWordTest()
        {
            string uikomst = $"<tr>" +
                $"<td>" +
                $"<span class=\"iconify\" data-icon=\"ant-design:file-word-filled\" data-inline=\"false\"></span>" +
                $"</td>" +
                $"<td><a href=\"{Word.Adress}\" target=\"_blank\">{Word.Naam}</a></td>" +
                $"<td>{Word.TijdToegevoegd.ToString("ddd dd/MM/yyyy, HH:mm")}</td>" +
                $"<tr>";
            Assert.Equal(uikomst, Word.Display());
        }
        [Fact]
        public void DisplayPowerPointTest()
        {
            string uikomst = $"<tr>" +
                $"<td>" +
                $"<span class=\"iconify\" data-icon=\"fa-regular:file-powerpoint\" data-inline=\"false\"></span>" +
                $"</td>" +
                $"<td><a href=\"{Powerpoint.Adress}\" target=\"_blank\">{Powerpoint.Naam}</a></td>" +
                $"<td>{Powerpoint.TijdToegevoegd.ToString("ddd dd/MM/yyyy, HH:mm")}</td>" +
                $"<tr>";
            Assert.Equal(uikomst, Powerpoint.Display());
        }
        [Fact]
        public void DisplayPdfTest()
        {
            string uikomst = $"<tr>" +
                $"<td>" +
                $"<span class=\"iconify\" data-icon=\"bx:bxs-file-pdf\" data-inline=\"false\"></span>" +
                $"</td>" +
                $"<td><a href=\"{Pdf.Adress}\" target=\"_blank\">{Pdf.Naam}</a></td>" +
                $"<td>{Pdf.TijdToegevoegd.ToString("ddd dd/MM/yyyy, HH:mm")}</td>" +
                $"<tr>";
            Assert.Equal(uikomst, Pdf.Display());
        }
        #endregion

    }
}
