using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IVideo
    {
        IEnumerable<Video> GetVideo();
        Video GetVideoById(int? id);
        IQueryable<VideoComment> GetVideoCommentByVideoId(int id);     
        void RemoveVideo(Video video);
        void AddVideo(Video video);
        void EditVideo(Video video);
        void RemoveRangeVideoComment(IQueryable<VideoComment> VideoComment);
       
    }
}
