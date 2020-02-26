using System;

namespace dotnet_g033.Models.Domain
{
    public class Afbeelding :Media
    {
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
        public override string Display()
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
