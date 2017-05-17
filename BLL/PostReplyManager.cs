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
   public class PostReplyManager
    {
        IPostReply irpost = DataAccess.CreatePostReply();
        public IEnumerable<PostReply> GetPostReply()
        {
            var rposts = irpost.GetPostReply();
            return rposts;
        }
        public PostReply GetPostReplyById(int? id)
        {
            PostReply rpost = irpost.GetPostReplyById(id);
            return rpost;
        }
        public IQueryable<PostReply> GetPostReplyByPostReplyId(int id)
        {
            var PostReply = irpost.GetPostReplyByPostReplyId(id);
            return PostReply;
        }

        public void RemovePostReply(PostReply rpost)
        {
            irpost.RemovePostReply(rpost);

        }

        public void RemoveRangePostReply(IQueryable<PostReply> PostReply)
        {
            irpost.RemoveRangePostReply(PostReply);
        }

       public IEnumerable<View_PostReply> GetPostReply(int postid)
       {
           var psr = irpost.GetPostReply(postid);
           return psr;
       }

       public void AddPostReply(PostReply postreply)
       {
           irpost.AddPostReply(postreply);
       }

       public void RemovePostReplyByPost_Id(int postid)
       {
           irpost.RemovePostReplyByPost_Id(postid);
       }
    }
}
