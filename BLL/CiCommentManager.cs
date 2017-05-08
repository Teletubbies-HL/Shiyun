using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DALFactory;

namespace BLL
{
   public class CiCommentManager
    {
        ICiComment icicomment = DataAccess.CreateCiComment();
        public IEnumerable<CiComment> GetCiComment()
        {
            var cicomment = icicomment.GetCiComment();
            return cicomment;
        }
        public CiComment GetCiCommentById(int? id)
        {
            CiComment cicomment = icicomment.GetCiCommentById(id);
            return cicomment;
        }
        public IQueryable<CiReply> GetCiReplyByCiCommentId(int id)
        {
            var CiReply = icicomment.GetCiReplyByCiCommentId(id);
            return CiReply;
        }
        
        public void RemoveCiComment(CiComment cicomment)
        {
            icicomment.RemoveCiComment(cicomment);

        }
       
        public void RemoveRangeCiReply(IQueryable<CiReply> CiReply)
        {
            icicomment.RemoveRangeCiReply(CiReply);
        }
      
    }
}
