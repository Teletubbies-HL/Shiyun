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
    }
}
