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
    public class SqlShiComment:IShiComment
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<ShiComment> GetShiComment()
        {
            var shicomment = db.ShiComment.ToList();
            return shicomment;
        }
        public ShiComment GetShiCommentById(int? id)
        {
            ShiComment shicomment = db.ShiComment.Find(id);
            return shicomment;
        }
        public IQueryable<ShiReply> GetShiReplyByShiCommentId(int id)
        {
            var ShiReply = db.ShiReply.Include("ShiComment").Where(c => c.ShiComment_id == id);
            return ShiReply;
        }

        public void RemoveShiComment(ShiComment shicomment)
        {
            //db.Shi.Add(goods);
            db.ShiComment.Remove(shicomment);
            db.SaveChanges();
        }


        public void RemoveRangeShiReply(IQueryable<ShiReply> ShiReply)
        {
            db.ShiReply.RemoveRange(ShiReply);
        }
    }
}
