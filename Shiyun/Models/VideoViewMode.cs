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
    }
}