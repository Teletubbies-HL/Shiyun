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
        public IEnumerable<Shi> Shi1 { get; set; }
        public IEnumerable<Shi> Shi2 { get; set; }
        public IEnumerable<Shi> Shi3 { get; set; }
        public IEnumerable<Shi> Shi4 { get; set; }
        public IEnumerable<Shi> Shi5 { get; set; }
        public IEnumerable<Shi> Shi6 { get; set; }
        public IEnumerable<Shi> Shinew22 { get; set; }
        public IEnumerable<Author> ShiAuthor1{ get; set; }
        public IEnumerable<Author> ShiAuthor2 { get; set; }
        public IEnumerable<Author> ShiAuthor3 { get; set; }
        public IEnumerable<ShiType> ShiTypetop12 { get; set; }
        public IEnumerable<Time> ShiTimetop11 { get; set; }

    }
}