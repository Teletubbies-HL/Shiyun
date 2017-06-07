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
   public class ShiCommentManager
    {
        IShiComment isc = DataAccess.CreateShiComment();
        public IEnumerable<ShiComment> GetShiComment()
        {
            var cicomment = isc.GetShiComment();
            return cicomment;
        }
        public ShiComment GetShiCommentById(int? id)
        {
            ShiComment cicomment = isc.GetShiCommentById(id);
            return cicomment;
        }
        public IEnumerable<ShiComment> GetShiComment(int id)
        {
            var CiComment = isc.GetShiComment();
            return CiComment;
        }
        public void AddShiComment(ShiComment shicomment)
        {
            isc.AddShiComment(shicomment);
        }
        public IQueryable<ShiReply> GetShiReplyByShiCommentId(int id)
        {
            var CiReply = isc.GetShiReplyByShiCommentId(id);
            return CiReply;
        }

        public void RemoveCiComment(ShiComment shicomment)
        {
            isc.RemoveShiComment(shicomment);

        }

        public void RemoveRangeCiReply(IQueryable<ShiReply> CiReply)
        {
            isc.RemoveRangeShiReply(CiReply);
        }
    }
}
