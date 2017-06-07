using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Shiyun.Models
{
    public class CiPaiViewModels
    {
       
        public IEnumerable<Ci> CiPaiCi { get; set; }
        public IEnumerable<CiComment> CiComment { get; set; }
        public IEnumerable<Ci> CiDetails { get; set; }
        public IEnumerable<CiPai> CiPai { get; set; }
        public IEnumerable<View_CiPaiCi> AllCi { get; set; }
        public Ci Ci { get; set; }
        //public CiComment CiComment { get; set; }

    }

}