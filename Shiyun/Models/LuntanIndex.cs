using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Shiyun.Models
{
    public class LuntanIndex
    {
        public IEnumerable<LunTan> FenLei { get; set; }
        public IEnumerable<View_PostIndex> HotPost { get; set; }
        public IEnumerable<View_PostIndex> ZongheTaolun { get; set; }
        public IEnumerable<View_PostIndex> PaiHang { get; set; }
        public IEnumerable<View_PostIndex> YuanChuangZd { get; set; }

        public IEnumerable<View_PostIndex> AllPost { get; set; }
        public IEnumerable<LunTan> LuntanName { get; set; }
        public int LuntanId { get; set; }
        public IEnumerable<SelectListItem> List1 { get; set; }
        public Post Post { get; set; }
        public PostReply PostReply { get; set; }
        public IEnumerable<View_PostIndex> PostDetails { get; set; } 
        public IEnumerable<View_PostReply> AllPostReply { get; set; }
    }
}