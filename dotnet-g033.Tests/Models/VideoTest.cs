using dotnet_g033.Models.Domain;
using dotnet_g033.Tests.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_g033.Tests.Models
{
    public class VideoTest
    {
        public Video VideoYoutube { get; set; }
        public Video Video { get; set; }
        private readonly DummyApplicationDbContext _dummyContext;
        public VideoTest()
        {
            _dummyContext = new DummyApplicationDbContext();
            this.VideoYoutube = _dummyContext.VideoYoutube;
            this.Video = _dummyContext.Video;
        }
        [Fact]
        public void DisplayTestYoutube() {
            String uitkomst = $"<div class=\"embed-responsive embed-responsive-16by9\"> <iframe class=\"embed-responsive-item\" src=\"https://www.youtube.com/embed/1Rcf8-yk6_o\" controls allowfullscreen></iframe></div>";
            Assert.Equal(uitkomst, VideoYoutube.Display());
        }
        [Fact]
        public void DisplayTestMp4()
        {
            String uitkomst = "<div class=\"embed-responsive embed-responsive-16by9\"><video class=\"embed-responsive-item\" controls=\"true\" preload=\"auto\"><source src=\"test.mp4\" type=\"video/mp4\"></video></div>";
            Assert.Equal(uitkomst, Video.Display());
        }
    }
}
