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
    public class SqlVideoReply:IVideoReply
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<VideoReply> GetVideoReply()
        {
            var videoreply = db.VideoReply.ToList();
            return videoreply;
        }
        public VideoReply GetVideoReplyById(int? id)
        {
            VideoReply videoreply = db.VideoReply.Find(id);
            return videoreply;
        }


        public void RemoveVideoReply(VideoReply videoreply)
        {
            //db.Shi.Add(goods);
            db.VideoReply.Remove(videoreply);
            db.SaveChanges();
        }
    }
}
