using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public class Video 
    {
        public int Id { get; set; }
        public String Adress { get; set; }
        public String Naam { get; set; }
        public DateTime TijdToegevoegd { get; set; }
        public MediaType MediaType { get; set; }
        public Video()
        {

        }
        public Video(String adress, String naam, DateTime tijdToegevoegd, MediaType mediaType)
        {
            this.Adress = adress;
            this.Naam = naam;
            this.TijdToegevoegd = tijdToegevoegd;
            this.MediaType = mediaType;
        }
        public string Display()
        {
            String uitvoer = "";
            switch (MediaType)
            {
                
                case MediaType.Video: string prefix = Adress.Split('.')[1].ToLower();
                    uitvoer = 
                        $"<div class=\"embed-responsive embed-responsive-16by9\">" +
                        $"<video class=\"embed-responsive-item\" controls=\"true\" preload=\"auto\">" +
                        $"<source src=\"{Adress}\" type=\"video/{prefix}\">" +
                        $"</video></div>";
                    break;
                case MediaType.YoutubeVideo: 
                    uitvoer = 
                        $"<div class=\"embed-responsive embed-responsive-16by9\"> " +
                        $"<iframe class=\"embed-responsive-item\" src=\"{Adress}\" controls allowfullscreen></iframe>" +
                        $"</div>";
                    break;
                default:
                    break;
            }

            return uitvoer;
        }
    }
}
