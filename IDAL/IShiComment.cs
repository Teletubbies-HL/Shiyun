using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IShiComment
    {
        IEnumerable<ShiComment> GetShiComment();
        ShiComment GetShiCommentById(int? id);
        IQueryable<ShiReply> GetShiReplyByShiCommentId(int id);

        void RemoveShiComment(ShiComment shicomment);
        void RemoveRangeShiReply(IQueryable<ShiReply> Shireply);
    }
}
