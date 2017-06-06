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
   public class CiReReplyManager
    {
        ICiReReply irpost = DataAccess.CreateCiReReply();
        public IEnumerable<CiReReply> GetPostReply()
        {
            var rposts = irpost.GetPostReply();
            return rposts;
        }
        public CiReReply GetPostReplyById(int? id)
        {
            CiReReply rpost = irpost.GetPostReplyById(id);
            return rpost;
        }
        public IQueryable<CiReReply> GetPostReplyByPostReplyId(int id)
        {
            var CiReReply = irpost.GetPostReplyByPostReplyId(id);
            return CiReReply;
        }

        public void RemovePostReply(CiReReply rpost)
        {
            irpost.RemovePostReply(rpost);

        }

        public void RemoveRangePostReply(IQueryable<CiReReply> CiReReply)
        {
            irpost.RemoveRangePostReply(CiReReply);
        }

       public IEnumerable<View_CiReply> GetPostReply(int postid)
       {
           var psr = irpost.GetPostReply(postid);
           return psr;
       }

       public void AddPostReply(CiReReply postreply)
       {
           irpost.AddPostReply(postreply);
       }

       public void RemovePostReplyByPost_Id(int postid)
       {
           irpost.RemovePostReplyByPost_Id(postid);
       }
    }
}
