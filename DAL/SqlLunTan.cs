using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;

namespace DAL
{
   public  class SqlLunTan:ILunTan
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<LunTan> GetFenlei()  //获取顶部分类
        {
            var fenlei = db.LunTan.ToList();
            return fenlei;
        }

       public IEnumerable<View_PostIndex> GetHostPost()  //获取热帖 根据点击量
       {
           var hotpost = from po in db.View_PostIndex
                         orderby po.Post_click
                         select po;
           
           //var hotpost2 = from n in db.Post
           //    join b in db.UserInfo on n.Users_id equals b.Users_id
           //    orderby n.AddTime descending
           //    select new
           //    {
           //        n.PostTitle,
           //        b.UserName
           //    };

            return hotpost.Take(5);
       }
        public IEnumerable<View_PostIndex> GetZhongheTaolun()  //获取综合讨论   Post_draft 草稿的意思
        {
            var zonghe = from po in db.View_PostIndex
                          where po.Post_recommend == 1 && po.Post_draft != 1
                          orderby po.AddTime descending 
                          select po;
            return zonghe.Take(3);
        }

       public IEnumerable<View_PostIndex> GetPaiHang() //获取前三排行
       {
            var paihang = from po in db.View_PostIndex
                         where po.LunTan_id ==1 
                         orderby po.Post_upvote - po.Post_down descending
                         select po;
            return paihang.Take(3);
        }

        public IEnumerable<View_PostIndex> GetYuanChuangZd(int luntanId)  //获取原创置顶
        {
            var yuanChuangZd = from po in db.View_PostIndex
                          where po.Post_top == 1 && po.LunTan_id == luntanId
                               orderby po.AddTime descending
                          select po;
            return yuanChuangZd.Take(3);
        }
        public IEnumerable<LunTan> GetLuntanName(int luntanId)  //获取论坛名称
        {
            var luntanName =   from lt in db.LunTan
                               where lt.LunTan_id == luntanId
                               select lt;
            return luntanName;
        }
        public IEnumerable<View_PostIndex> GetAllPost(int luntanId)  //获取所有帖子
        {
            var yuanChuangZd = from po in db.View_PostIndex
                               where po.LunTan_id == luntanId && po.Post_draft !=1
                               orderby po.AddTime descending
                               select po;
            return yuanChuangZd;
        }
    }
}
