using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using System.Data.Entity;

namespace DAL
{
    public class SqlCiReReply:ICiReReply
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<CiReReply> GetPostReply()
        {
            var rposts = db.CiReReply.ToList();
            return rposts;
        }
        public CiReReply GetPostReplyById(int? id)
        {
            CiReReply rpost = db.CiReReply.Find(id);
            return rpost;
        }
        public IQueryable<CiReReply> GetPostReplyByPostReplyId(int id)
        {
            var rpost = db.CiReReply.Include("CiReReply").Where(o => o.Reply_id == id);
            return rpost;
        }
        public void RemovePostReply(CiReReply rpost)
        {
            db.CiReReply.Remove(rpost);
            db.SaveChanges();
        }


        public void RemoveRangePostReply(IQueryable<CiReReply> CiReReply)
        {
            db.CiReReply.RemoveRange(CiReReply);
        }
        public IEnumerable<View_CiReply> GetPostReply(int postid) //获取帖子回复
        {
            var psr =  from po in db.View_CiReply
                       where po.Ci_id1 == postid
                       orderby po.ReplyTime1 descending
                       select po;
            return psr;
        }
        public void AddPostReply(CiReReply postreply) //添加回复
        {
            db.CiReReply.Add(postreply);
            db.SaveChanges();
        }
        public void RemovePostReplyByPost_Id(int postid)  //删除评论by post_id
        {
            var psr = from po in db.CiReReply
                      where po.Ci_id == postid
                      select po;
            foreach (var ei in psr)
            {
                db.CiReReply.Remove(ei);      
            }
            db.SaveChanges();
        }
    }
}
