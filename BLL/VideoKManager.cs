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
   public class VideoKManager
    {
        IVideoK ivideok = DataAccess.CreateVideoK();
        public IEnumerable<VideoK> GetVideoK()
        {
            var videoks = ivideok.GetVideoK();
            return videoks;
        }
        public VideoK GetVideoKById(int? id)
        {
            VideoK videok = ivideok.GetVideoKById(id);
            return videok;
        }
        public IQueryable<VideoK> GetVideoKByVideoKId(int? id)
        {
            var Video = ivideok.GetVideoKByVideoKId(id);
            return Video;
        }

        public void RemoveVideoK(VideoK shi)
        {
            ivideok.RemoveVideoK(shi);

        }
        public void AddVideoK(VideoK shi)
        {
            ivideok.AddVideoK(shi);

        }
        public void EditVideoK(VideoK shi)
        {
            ivideok.EditVideoK(shi);

        }
        public void RemoveRangeVideo(IQueryable<Video> Video)
        {
            ivideok.RemoveRangeVideo(Video);
        }
    }
}
