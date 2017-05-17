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
    public class SqlPostReply:IPostReply
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<PostReply> GetPostReply()
        {
            var rposts = db.PostReply.ToList();
            return rposts;
        }
        public PostReply GetPostReplyById(int? id)
        {
            PostReply rpost = db.PostReply.Find(id);
            return rpost;
        }
        public IQueryable<PostReply> GetPostReplyByPostReplyId(int id)
        {
            var rpost = db.PostReply.Include("PostReply").Where(o => o.Reply_id == id);
            return rpost;
        }
        public void RemovePostReply(PostReply rpost)
        {
            db.PostReply.Remove(rpost);
            db.SaveChanges();
        }


        public void RemoveRangePostReply(IQueryable<PostReply> PostReply)
        {
            db.PostReply.RemoveRange(PostReply);
        }
        public IEnumerable<View_PostReply> GetPostReply(int postid) //获取帖子回复
        {
            var psr =  from po in db.View_PostReply
                       where po.Post_id1 == postid
                       orderby po.ReplyTime1 descending
                       select po;
            return psr;
        }
        public void AddPostReply(PostReply postreply) //添加回复
        {
            db.PostReply.Add(postreply);
            db.SaveChanges();
        }
        public void RemovePostReplyByPost_Id(int postid)  //删除评论by post_id
        {
            var psr = from po in db.PostReply
                      where po.Post_id == postid
                      select po;
            foreach (var ei in psr)
            {
                db.PostReply.Remove(ei);      
            }
            db.SaveChanges();
        }
    }
}
