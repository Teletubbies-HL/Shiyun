using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IPostReply
    {
        IEnumerable<PostReply> GetPostReply();
        PostReply GetPostReplyById(int? id);
        IQueryable<PostReply> GetPostReplyByPostReplyId(int id);
        void RemovePostReply(PostReply postr);
        void RemoveRangePostReply(IQueryable<PostReply> PostReply);
        IEnumerable<View_PostReply> GetPostReply(int postid);
        void AddPostReply(PostReply postreply);
        void RemovePostReplyByPost_Id(int postid);
    }
}
