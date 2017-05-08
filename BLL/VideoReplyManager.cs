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
   public class VideoReplyManager
    {
        IVideoReply ivideoreply = DataAccess.CreateVideoReply();
        public IEnumerable<VideoReply> GetVideoReply()
        {
            var shireply = ivideoreply.GetVideoReply();
            return shireply;
        }
        public VideoReply GetVideoReplyById(int? id)
        {
            VideoReply videoreply = ivideoreply.GetVideoReplyById(id);
            return videoreply;
        }
        public void RemoveVideoReply(VideoReply videoreply)
        {
            ivideoreply.RemoveVideoReply(videoreply);

        }
    }
}
