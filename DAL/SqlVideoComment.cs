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
    public class SqlVideoComment:IVideoComment
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<VideoComment> GetVideoComment()
        {
            var videocomments = db.VideoComment.ToList();
            return videocomments;
        }
        public VideoComment GetVideoCommentById(int? id)
        {
            VideoComment videocomment = db.VideoComment.Find(id);
            return videocomment;
        }
        public IQueryable<VideoReply> GetVideoReplyByVideoCommentId(int id)
        {
            var VideoReply = db.VideoReply.Include("VideoComment").Where(c => c.VideoComment_id == id);
            return VideoReply;
        }

        public void RemoveVideoComment(VideoComment videocomment)
        {
            //db.Shi.Add(goods);
            db.VideoComment.Remove(videocomment);
            db.SaveChanges();
        }
      

        public void RemoveRangeVideoReply(IQueryable<VideoReply> VideoReply)
        {
            db.VideoReply.RemoveRange(VideoReply);
        }
        public void AddComment(VideoComment comment)
        {
            db.VideoComment.Add(comment);
            db.SaveChanges();
        }
    }
}
