using System;

namespace dotnet_g033.Models.Domain
{
    public class Afbeelding
    {
        public int Id { get; set; }
        public String Adress { get; set; }
        public String Naam { get; set; }
        public DateTime TijdToegevoegd { get; set; }
        public MediaType MediaType { get; set; }
        public Afbeelding()
        {

        }
        public Afbeelding(String adress, String naam, DateTime tijdToegevoegd, MediaType mediaType)
        {
            this.Adress = adress;
            this.Naam = naam;
            this.TijdToegevoegd = tijdToegevoegd;
            this.MediaType = mediaType;
        }
        public string Display()
        {
            
            String uitvoer = $"<a href=\"{Adress}\" target=\"_blank\">" +
                    $"<img src=\"{Adress}\" alt=\"{Naam}\" style = \"width:100%\"> " +
                    $"<div class=\"caption\">" +
                        $"<p>{Naam}</p>" +
                    $"</div>" +
                $"</a>";
            return uitvoer;
        }
    }
}
