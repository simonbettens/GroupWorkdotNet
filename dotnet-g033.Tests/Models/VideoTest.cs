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
        
    }
}
