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
    public class SqlVideoK:IVideoK
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<VideoK> GetVideoK()  //获取全部视频分类
        {
            var videoks = db.VideoK.OrderByDescending(c =>c.AddTime).ToList();
            return videoks;
        }
        public VideoK GetVideoKById(int? id)
        {
            VideoK videok = db.VideoK.Find(id);
            return videok;
        }
        public IQueryable<VideoK> GetVideoKByVideoKId(int? id)
        {
            var Video = db.VideoK.Where(c => c.VideoK_id == id);
            return Video;
        }

        public void RemoveVideoK(VideoK videok)
        {
            //db.Shi.Add(goods);
            db.VideoK.Remove(videok);
            db.SaveChanges();
        }
        public void AddVideoK(VideoK videok)
        {
            db.VideoK.Add(videok);
            db.SaveChanges();
        }
        public void EditVideoK(VideoK videok)
        {
            db.Entry(videok).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveRangeVideo(IQueryable<Video> Video)
        {
            db.Video.RemoveRange(Video);
        }
    }
}
