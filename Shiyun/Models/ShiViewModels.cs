using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Shiyun.Models
{
    public class ShiViewModels
    {
        #region ShiShow展示
        public IEnumerable<Shi> Shitop8 { get; set; }
        public IEnumerable<Shi> Shi1 { get; set; }
        public IEnumerable<Shi> Shi2 { get; set; }
        public IEnumerable<Shi> Shi3 { get; set; }
        public IEnumerable<Shi> Shi4 { get; set; }
        public IEnumerable<Shi> Shi5 { get; set; }
        public IEnumerable<Shi> Shi6 { get; set; }
        public IEnumerable<Shi> Shinew22 { get; set; }
        public IEnumerable<Author> ShiAuthor1 { get; set; }
        public IEnumerable<Author> ShiAuthor2 { get; set; }
        public IEnumerable<Author> ShiAuthor3 { get; set; }
        public IEnumerable<ShiType> ShiTypetop12 { get; set; }
        public IEnumerable<Time> ShiTimetop11 { get; set; }
        #endregion


        #region CiShow展示
        public IEnumerable<Ci> Citop7 { get; set; }
        public IEnumerable<Author> CiAuthor1 { get; set; }
        public IEnumerable<Author> CiAuthor2 { get; set; }
        public IEnumerable<Author> CiAuthor3 { get; set; }
        public IEnumerable<Author> CiAuthor4 { get; set; }
        public IEnumerable<Author> CiAuthor5 { get; set; }
        public IEnumerable<Author> CiAuthor6 { get; set; }
        //public IEnumerable<Author> Shinew22 { get; set; }
        //public IEnumerable<Author> CiAuthor1 { get; set; }
        //public IEnumerable<Author> ShiAuthor2 { get; set; }
        //public IEnumerable<Author> ShiAuthor3 { get; set; }
        //public IEnumerable<ShiType> ShiTypetop12 { get; set; }
        //public IEnumerable<Time> ShiTimetop11 { get; set; }
        #endregion

        public View_CiShow CiShow { get; set; }
    }

}