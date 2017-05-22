using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
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
            return View(videoViewMode);
        }
    }
}