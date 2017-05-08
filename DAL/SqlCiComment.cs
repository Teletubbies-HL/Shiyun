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
    public class SqlCiComment:ICiComment
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<CiComment> GetCiComment()
        {
            var cicomments = db.CiComment.ToList();
            return cicomments;
        }
        public CiComment GetCiCommentById(int? id)
        {
            CiComment goods = db.CiComment.Find(id);
            return goods;
        }
        public IQueryable<CiReply> GetCiReplyByCiCommentId(int id)
        {
            var CiReply = db.CiReply.Include("CiComment").Where(c => c.CiComment_id == id);
            return CiReply;
        }
        
        public void RemoveCiComment(CiComment cicomment)
        {
            db.CiComment.Remove(cicomment);
            db.SaveChanges();
        }      

        public void RemoveRangeCiReply(IQueryable<CiReply> CiReply)
        {
            db.CiReply.RemoveRange(CiReply);
        }
       
    }
}
