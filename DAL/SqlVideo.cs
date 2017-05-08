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
    public class SqlVideo:IVideo
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Video> GetVideo()
        {
            var videos = db.Video.ToList();
            return videos;
        }
        public Video GetVideoById(int? id)
        {
            Video video = db.Video.Find(id);
            return video;
        }
        public IQueryable<VideoComment> GetVideoCommentByVideoId(int id)
        {
            var VideoComment = db.VideoComment.Include("Video").Where(c => c.Video_id == id);
            return VideoComment;
        }

        public void RemoveVideo(Video video)
        {
            //db.Shi.Add(goods);
            db.Video.Remove(video);
            db.SaveChanges();
        }
        public void AddVideo(Video video)
        {
            db.Video.Add(video);
            db.SaveChanges();
        }
        public void EditVideo(Video video)
        {
            db.Entry(video).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveRangeVideoComment(IQueryable<VideoComment> VideoComment)
        {
            db.VideoComment.RemoveRange(VideoComment);
        }
    }
}
