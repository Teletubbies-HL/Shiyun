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
   public class VideoCommentManager
    {
        IVideoComment ivideoc = DataAccess.CreateVideoComment();
        public IEnumerable<VideoComment> GetVideoComment()
        {
            var videocs = ivideoc.GetVideoComment();
            return videocs;
        }
        public VideoComment GetVideoCommentById(int? id)
        {
            VideoComment videoc = ivideoc.GetVideoCommentById(id);
            return videoc;
        }
        public IQueryable<VideoReply> GetVideoReplyByVideoCommentId(int id)
        {
            var VideoReply = ivideoc.GetVideoReplyByVideoCommentId(id);
            return VideoReply;
        }

        public void RemoveVideo(VideoComment videocomment)
        {
            ivideoc.RemoveVideoComment(videocomment);

        }
        
        public void RemoveRangeVideoReply(IQueryable<VideoReply> VideoReply)
        {
            ivideoc.RemoveRangeVideoReply(VideoReply);
        }
    }
}
