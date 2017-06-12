using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IVideoComment
    {
        IEnumerable<VideoComment> GetVideoComment();
        VideoComment GetVideoCommentById(int? id);
        IQueryable<VideoReply> GetVideoReplyByVideoCommentId(int id);
        void RemoveVideoComment(VideoComment videocomment);
       
        void RemoveRangeVideoReply(IQueryable<VideoReply> VideoReply);
        void AddComment(VideoComment comment);
    }
}
