using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using PagedList;
using Shiyun.Models;

namespace Shiyun.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        ShiyunEntities db = new ShiyunEntities();
        VideoKManager vkm = new VideoKManager();
       VideoManager vm = new VideoManager();
        public ActionResult Index()
        {
            VideoViewMode videoViewMode = new VideoViewMode();
            videoViewMode.GetAllVideo = vkm.GetVideoK();
            videoViewMode.GetNewVideo = vm.GetNewVideo().Take(3);
            videoViewMode.GetRecommend = vm.GetRecommend().Take(2);
            return View(videoViewMode);
        }
        #region Video分页数据获取
        public ActionResult GetAllVideoK(int? page)
        {
            var post = vkm.GetVideoK();
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(post.ToPagedList(pageNumber, pageSize));
        }
        #endregion
        public ActionResult VideoDetails(int ? VideoK_id ,int ? Video_id)
        {
            VideoViewMode videoViewMode = new VideoViewMode();
            string videokid = VideoK_id+"01";
            
            if (Video_id == null)
            {
                videoViewMode.Video1 = vm.GetVideoById(int.Parse(videokid));
            }
            else
            {
                videoViewMode.Video1 = vm.GetVideoById(Video_id);
            }
            videoViewMode.Video2 = vm.GetVideoByVideoKId(VideoK_id);
            videoViewMode.VideoK1 = vkm.GetVideoKByVideoKId(VideoK_id);
            videoViewMode.GetNewVideo = vm.GetNewVideo().Take(4);  
            return View(videoViewMode);
        }
    }
}