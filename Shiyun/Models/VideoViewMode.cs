using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Models;

namespace Shiyun.Models
{
    public class VideoViewMode
    {
        
        public IEnumerable<VideoK> GetAllVideo { get; set; }
        public IEnumerable<Video> GetNewVideo { get; set; }
        public IEnumerable<Video> GetRecommend { get; set; }
        public IEnumerable<Video> Video1 { get; set; }
        public IEnumerable<Video> Video2 { get; set; }
        public IEnumerable<VideoK> VideoK1 { get; set; }
    }
}