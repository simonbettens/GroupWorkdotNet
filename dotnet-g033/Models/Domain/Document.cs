using System;

namespace dotnet_g033.Models.Domain
{
    public class Document
    {
        public int Id { get; set; }
        public String Adress { get; set; }
        public String Naam { get; set; }
        public DateTime TijdToegevoegd { get; set; }
        public MediaType MediaType { get; set; }
        public Document()
        {

        }
        public Document(string adress, string naam, DateTime toegevoegd, MediaType mediaType)
        {
            this.Adress = adress;
            this.Naam = naam;
            this.TijdToegevoegd = toegevoegd;
            this.MediaType = mediaType;
        }
        public string Display()
        {
            string icoon = "";
            switch (MediaType)
            {

                case MediaType.Excel:
                    icoon = "<span class=\"iconify\" data-icon=\"ant-design:file-excel-outlined\" data-inline=\"false\"></span>";
                    break;
                case MediaType.Word:
                    icoon = "<span class=\"iconify\" data-icon=\"ant-design:file-word-filled\" data-inline=\"false\"></span>";
                    break;
                case MediaType.Pdf:
                    icoon = "<span class=\"iconify\" data-icon=\"bx:bxs-file-pdf\" data-inline=\"false\"></span>";
                    break;
                case MediaType.Powerpoint:
                    icoon = "<span class=\"iconify\" data-icon=\"fa-regular:file-powerpoint\" data-inline=\"false\"></span>";
                    break;
                case MediaType.Zip:
                    icoon = "<span class=\"iconify\" data-icon=\"ant-design:file-zip-filled\" data-inline=\"false\"></span>";
                    break;
                default:
                    break;
            }

            return $"<tr>" +
                $"<td>{icoon}</td>" +
                $"<td><a href=\"{Adress}\" target=\"_blank\">{Naam}</a></td>" +
                $"<td>{TijdToegevoegd.ToString("ddd dd/MM/yyyy, HH:mm")}</td>" +
                $"<tr>";
        }
    }
}
