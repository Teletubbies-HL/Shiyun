using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Shiyun.Models
{
    public class UserCenterViewModel
    {
        public IEnumerable<UserInfo> Uses1 { get; set; }
        public int UserA { get; set; }
        public int UserB { get; set; }
        public IEnumerable<View_PostIndex> Post1 { get; set; }
        public IEnumerable<View_PostIndex> Post2 { get; set; }
        public IEnumerable<View_PostIndex> Post3 { get; set; }
    }
}