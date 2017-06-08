using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Shiyun.Models
{
    public class TimeViewModels
    {
        

        public IEnumerable<View_CiShow> CiShow { get; set; }
        public IEnumerable<View_Authorsc> Authorsc { get; set; }
        public IEnumerable<Time> Time { get; set; }
        public IEnumerable<Author> TimeAuthor { get; set; }
        public IEnumerable<View_TimeShi> Times { get; set; }

    }

}