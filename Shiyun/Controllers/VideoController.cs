using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using PagedList;
using Shiyun.Attributes;
using Shiyun.Models;

namespace Shiyun.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        ShiyunEntities db = new ShiyunEntities();
        VideoKManager vkm = new VideoKManager();
        VideoManager vm = new VideoManager();
        VideoCommentManager vcm = new VideoCommentManager();
        VideoReplyManager vrm = new VideoReplyManager();
        public ActionResult Index1()
        {
            VideoViewMode videoViewMode = new VideoViewMode();
            videoViewMode.GetAllVideo = vkm.GetVideoK();
            videoViewMode.GetNewVideo = vm.GetNewVideo().Take(3);
            videoViewMode.GetRecommend = vm.GetRecommend().Take(2);
            return View(videoViewMode);
        }
        //public ActionResult Index()
        //{
        //    VideoViewMode videoViewMode = new VideoViewMode();
        //    videoViewMode.GetAllVideo = vkm.GetVideoK();
        //    videoViewMode.GetNewVideo = vm.GetNewVideo().Take(3);
        //    videoViewMode.GetRecommend = vm.GetRecommend().Take(2);
        //    return View(videoViewMode);
        //}
        #region Video分页数据获取
        public ActionResult GetAllVideoK(int? page)
        {
            var post = vkm.GetVideoK();
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(post.ToPagedList(pageNumber, pageSize));
        }
        #endregion
        public ActionResult VideoDetails(int? VideoK_id, int? Video_id)
        {
            VideoViewMode videoViewMode = new VideoViewMode();
            string videokid = VideoK_id + "01";
           
            if (Video_id == null)
            {
                Session["Video_id"] = videokid;
                videoViewMode.Video1 = vm.GetVideoById(int.Parse(videokid));
            }
            else
            {
                Session["Video_id"] = Video_id;
                videoViewMode.Video1 = vm.GetVideoById(Video_id);
            }
            videoViewMode.Video2 = vm.GetVideoByVideoKId(VideoK_id);
            videoViewMode.VideoK1 = vkm.GetVideoKByVideoKId(VideoK_id);
            videoViewMode.GetNewVideo = vm.GetNewVideo().Take(4);
            return View(videoViewMode);
        }

        #region 评论回复
        public ActionResult AddComments(int? VideoK_id, int ?Video_id)
        {
            string videokid = VideoK_id + "01";
            if (Video_id == null)
            {
                Session["Video_id"] = videokid;             
            }
            else
            {
                Session["Video_id"] = Video_id;
            }

            Video_id = Convert.ToInt32(Session["Video_id"]);
            var comment = vm.GetVideoCommentByVideoId(Video_id);
            return View(comment);
        }
        [HttpPost]
        [ValidateInput(false)]
        [Login]
        public ActionResult AddComments(VideoComment VideoComment)
        {
            int Video_id = Convert.ToInt32(Session["Video_id"]);
            string userid = (Session["Users_id"]).ToString();
            string textarea = Request["pingluntextarea"];
            if (ModelState.IsValid)
            {
                if (textarea != "")
                {
                    VideoComment.Users_id = userid.ToString();
                    VideoComment.Video_id = Video_id;
                    VideoComment.ComTime = System.DateTime.Now;
                    VideoComment.ComContent = textarea;
                    vcm.AddComment(VideoComment);
                }
                else
                {
                    return Content("<script>alert('评论不能为空！');history.go(-1)</script>");
                }
            }
            return RedirectToAction("VideoDetails", "Video", new { Video_id = Video_id });
        }
        public ActionResult ReplyComments()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReplyComments(int videoCommentId, VideoReply VideoReply)
        {
            string replytext = Request.Form["textarea1"];
            if (replytext == "")
            {
                return Content("<script>;alert('回复不能为空');history.go(-1)</script>");
            }
            else
            {
                string userid = (Session["Users_id"]).ToString();
                VideoReply.VideoComment_id= videoCommentId;
                VideoReply.Users_id = userid.ToString();
                VideoReply.ReplyContent = replytext;
                VideoReply.ReplyTim = DateTime.Now;
                vrm.AddReply(VideoReply);
                return Content("<script>alert('回复成功！');history.go(-1)</script>");
            }
        }
        #endregion
    }
}