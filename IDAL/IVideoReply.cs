using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IVideoReply
    {
        IEnumerable<VideoReply> GetVideoReply();
        VideoReply GetVideoReplyById(int? id);

        void RemoveVideoReply(VideoReply videoreply);
        void AddReply(VideoReply videoReply);
    }
}
