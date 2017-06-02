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

       public IEnumerable<Post> Search(string search)
       {
            var posts = ipost.Search(search);
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

       public IEnumerable<View_PostIndex> GetPostByUser(string uid, int ltid)
       {
            var pstd = ipost.GetPostByUser(uid,ltid);
            return pstd;
        }
       public IEnumerable<View_PostIndex> GetPostDetails(int postid)
       {
           var pstd = ipost.GetPostDetails(postid);
           return pstd;
       }

       public void RemovePostByPost_Id(int postid)
       {
           ipost.RemovePostByPost_Id(postid);
       }

       public IEnumerable<View_PostIndex> GetAllPostByZan()
       {
            var allPost = ipost.GetAllPostByZan();
            return allPost;
        }

       public IEnumerable<View_PostIndex> GetAllPostByCai()
       {
            var allPost = ipost.GetAllPostByCai();
            return allPost;
        }

       public IEnumerable<View_PostIndex> GetAllPostByClick()
       {
            var allPost = ipost.GetAllPostByClick();
            return allPost;
        }

       public IEnumerable<View_PostIndex> Zan1(string con, int postid)
       {
           var zan1 = ipost.Zan1(con, postid);
           return zan1;
       }

       public IEnumerable<View_PostIndex> Cai1(string con, int postid)
       {
            var cai1 = ipost.Cai1(con, postid);
            return cai1;
        }
    }
}
