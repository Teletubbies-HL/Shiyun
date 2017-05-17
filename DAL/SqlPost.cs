using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using System.Data.Entity;

namespace DAL
{
    public class SqlPost:IPost
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Post> GetPost()
        {
            var posts = db.Post.ToList();
            return posts;
        }

        public IQueryable<PostReply> GetPostReplyByPostId(int id)
        {
            var post = db.PostReply.Include("Post").Where(o => o.Post_id == id);
            return post;
        }
        public void RemovePost(Post post)
        {
            db.Post.Remove(post);
            db.SaveChanges();
        }
        public void AddPost(Post post)
        {
            db.Post.Add(post);
            db.SaveChanges();
        }
        

        public void RemoveRangePostReply(IQueryable<PostReply> PostReply)
        {
            db.PostReply.RemoveRange(PostReply);
        }
        public int CountPostById(int pid)
        {
            var pt = db.Post.Where(c => c.Post_id == pid).Select(c => c.Post_id).Count();
            return pt;
        }
        public IEnumerable<View_PostIndex> GetPostDetails(int postid) //获取帖子详情
        {
            var pstd = from po in db.View_PostIndex
                       where po.Post_id == postid                         
                          select po;
            return pstd;
        }
        public void RemovePostByPost_Id(int postid)  //删除帖子by post_id
        {
            var pstd = from po in db.Post
                      where po.Post_id == postid
                      select po;
             db.Post.Remove(pstd.FirstOrDefault());           
            db.SaveChanges();
        }
        public void EditPost(Post post) //更新
        {
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
        }
        public Post GetPostById(int? id)  //获取postbyid
        {
            Post post = db.Post.Where(c => c.Post_id == id)
                .FirstOrDefault();
            return post;
        }
    }
}
