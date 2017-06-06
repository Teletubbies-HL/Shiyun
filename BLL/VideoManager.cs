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
   public class VideoManager
    {
        IVideo ivideo = DataAccess.CreateVideo();
        public IEnumerable<Video> GetVideo()
        {
            var videos = ivideo.GetVideo();
            return videos;
        }

       public IEnumerable<Video> Search(string search)
       {
            var videos = ivideo.Search(search);
            return videos;
        }
        public IEnumerable<Video> GetVideoById(int? id)
        {
            var video = ivideo.GetVideoById(id);
            return video;
        }
        public IEnumerable<Video> GetVideoByVideoKId(int? id)
        {
            var video = ivideo.GetVideoByVideoKId(id);
            return video;
        }

        public IQueryable<VideoComment> GetVideoCommentByVideoId(int id)
        {
            var VideoComment = ivideo.GetVideoCommentByVideoId(id);
            return VideoComment;
        }

        public void RemoveVideo(Video shi)
        {
            ivideo.RemoveVideo(shi);

        }
        public void AddVideo(Video shi)
        {
            ivideo.AddVideo(shi);

        }
        public void EditVideo(Video shi)
        {
            ivideo.EditVideo(shi);

        }
        public void RemoveRangeVideoComment(IQueryable<VideoComment> VideoComment)
        {
            ivideo.RemoveRangeVideoComment(VideoComment);
        }

       public IEnumerable<Video> GetNewVideo()
       {
           var getnewvideo = ivideo.GetNewVideo();
           return getnewvideo;
       }

       public IEnumerable<Video> GetRecommend()
       {
           var recommend = ivideo.GetRecommend();
           return recommend;
       }
    }
}
