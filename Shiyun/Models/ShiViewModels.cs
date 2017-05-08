using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Shiyun.Models
{
    public class ShiViewModels
    {
       
        public IEnumerable<Shi> Shitop8 { get; set; }
        public IEnumerable<Shi> ShiAuthortop20 { get; set; }
        public IEnumerable<Shi> ShiTypetop20 { get; set; }
        public IEnumerable<Shi> ShiTimetop20 { get; set; }

    }
}