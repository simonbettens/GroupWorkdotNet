using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g033.Models.Domain
{
    public class Video : Media
    {
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
        public override string Display()
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
