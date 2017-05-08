using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IPost
    {
        IEnumerable<Post> GetPost();
        Post GetPostById(int? id);
        IQueryable<PostReply> GetPostReplyByPostId(int id);
        void RemovePost(Post post);
        void AddPost(Post post);
        void EditPost(Post post);
        int CountPostById(int pid);
        void RemoveRangePostReply(IQueryable<PostReply> PostReply);
    }
}
