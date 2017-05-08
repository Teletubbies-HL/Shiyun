using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  ICiComment
    {
        IEnumerable<CiComment> GetCiComment();
        CiComment GetCiCommentById(int? id);
        IQueryable<CiReply> GetCiReplyByCiCommentId(int id);    
        void RemoveCiComment(CiComment cicomment);
        void RemoveRangeCiReply(IQueryable<CiReply> CiReply);
       

    }
}
