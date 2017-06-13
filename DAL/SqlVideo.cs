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
        public IEnumerable<Video> Search(string search)
        {
            var videos = db.Video.Where(c => c.VideoName.Contains(search)).ToList();
            return videos;
        }
        public IEnumerable<Video> GetVideoById(int? id)
        {
            var video = from vi in db.Video
                        where vi.Video_id == id
                        select vi;
            return video;
        }
        public IEnumerable<Video> GetVideoByVideoKId(int? id)
        {
            var video = from vi in db.Video
                        where vi.VideoK_id == id
                        select vi;
            return video;
        }
        public IQueryable<VideoComment> GetVideoCommentByVideoId(int ?id)
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
        public IEnumerable<Video> GetNewVideo() //获取最新的视频
        {
            var newvideo = from po in db.Video
                               orderby po.AddTime descending
                               select po;
            return newvideo;
        }
        public IEnumerable<Video> GetRecommend() //获取推荐的视频
        {
            var recommend = from po in db.Video
                           where po.Video_recommend == 1
                           orderby po.AddTime descending
                           select po;
            return recommend;
        }
    }
}
