using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IVideoK
    {
        IEnumerable<VideoK> GetVideoK();
        VideoK GetVideoKById(int? id);
        IQueryable<Video> GetVideoByVideoKId(int id);
        void RemoveVideoK(VideoK video);
        void AddVideoK(VideoK video);
        void EditVideoK(VideoK video);
        void RemoveRangeVideo(IQueryable<Video> Video);
    }
}
