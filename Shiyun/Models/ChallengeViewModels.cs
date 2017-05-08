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
    }
}