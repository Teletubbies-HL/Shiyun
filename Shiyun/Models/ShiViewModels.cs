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
        public IEnumerable<Author> GetAuthorById { get; set; }

        public IEnumerable<CiPai> CiPai1 { get; set; }
        public IEnumerable<CiPai> CiPai2 { get; set; }
        public IEnumerable<CiPai> CiPai3 { get; set; }
        public IEnumerable<CiPai> CiPai4 { get; set; }
        public IEnumerable<CiPai> CiPai5 { get; set; }
        public IEnumerable<CiPai> CiPai6 { get; set; }

        public IEnumerable<Ci> Ci1 { get; set; }
        public IEnumerable<Ci> Ci2 { get; set; }
        public IEnumerable<Ci> Ci3 { get; set; }
        public IEnumerable<Ci> Ci4{ get; set; }
        public IEnumerable<Ci> Ci5 { get; set; }
        public IEnumerable<Ci> Ci6 { get; set; }
        #endregion

        public IEnumerable<View_CiShow> CiShow { get; set; }
        public IEnumerable<View_Authorsc> Authorsc { get; set; }
        public IEnumerable<View_AuthorShi> Authors { get; set; }
        public IEnumerable<View_AuthorCi> Authorc { get; set; }

    }

}