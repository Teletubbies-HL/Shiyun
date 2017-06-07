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
        public UserInfo UserInfo { get; set; } //用来修改资料
        public int UserA { get; set; }  //关注数
        public IEnumerable<View_UserInfo> UsesAa { get; set; }
        public int UserB { get; set; }   //粉丝数
        public IEnumerable<View_UserInfo> UsesBb { get; set; }
        public IEnumerable<View_PostIndex> Post1 { get; set; }
        public IEnumerable<View_PostIndex> PostYuanChuang { get; set; }
        public IEnumerable<View_PostIndex> Post2 { get; set; }
        public IEnumerable<View_PostIndex> Post3 { get; set; }
        public IEnumerable<View_PostIndex> Draft { get; set; }
        //public IEnumerable<Us> postreply { get; set; }
        //public IEnumerable<> 
    }
}