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
   public class PostManager
    {
        IPost ipost = DataAccess.CreatePost();
        public IEnumerable<Post> GetPost()
        {
            var posts = ipost.GetPost();
            return posts;
        }
        public Post GetPostById(int? id)
        {
            Post post = ipost.GetPostById(id);
            return post;
        }
        public IQueryable<PostReply> GetPostReplyByPostId(int id)
        {
            var PostReply = ipost.GetPostReplyByPostId(id);
            return PostReply;
        }

        public void RemovePost(Post post)
        {
            ipost.RemovePost(post);

        }
        public void AddPost(Post post)
        {
            ipost.AddPost(post);

        }
        public void EditPost(Post post)
        {
            ipost.EditPost(post);

        }
        public void RemoveRangePostReply(IQueryable<PostReply> PostReply)
        {
            ipost.RemoveRangePostReply(PostReply);
        }

       public int CountPostById(int pid)
       {
           var pt = ipost.CountPostById(pid);
           return pt;
       }
    }
}
