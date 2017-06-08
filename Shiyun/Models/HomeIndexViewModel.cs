using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Shiyun.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Shi> Shi1 { get; set; }
        public IEnumerable<Shi> Shi2 { get; set; }
        public IEnumerable<Ci> Ci1 { get; set; }
        public IEnumerable<Ci> Ci2 { get; set; }
        public IEnumerable<UserInfo> UserInfo1 { get; set; }
        public IEnumerable<View_PostIndex> PostPaihang { get; set; }
    }
}