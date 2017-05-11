using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Shiyun.Models
{
    public class ChallengeViewModels
    {
        public IEnumerable<Challenge> Challenge1 { get; set; }
        public IEnumerable<Challenge> Challenge2 { get; set; }
        public IEnumerable<Challenge> Challenge3 { get; set; }
        public IEnumerable<Challenge> Challenge4 { get; set; }
        public IEnumerable<Challenge> Challenge5 { get; set; }
        public IEnumerable<Challenge> Challenge6 { get; set; }
        public IEnumerable<Challenge> Challenge7 { get; set; }
    }
}