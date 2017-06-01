using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace Shiyun.Controllers
{
    public class SearchController : Controller
    {
        UserInfoManager userInfoManager = new UserInfoManager();
        ShiManager shiManager = new ShiManager();
        CiManager ciManager = new CiManager();
        PostManager postManager = new PostManager();
        GoodsManager goodsManager = new GoodsManager();
        AuthorManager authorManager = new AuthorManager();
        TimeManager timeManager = new TimeManager();
        VideoManager videoManager = new VideoManager();
        Models.SearchViewModel searchvm = new Models.SearchViewModel();
        // GET: Search
        public ActionResult Index()
        {
            string search=Session["Search"].ToString();
            searchvm.Shi1 = shiManager.Search(search);
            searchvm.Ci1 = ciManager.Search(search);
            searchvm.Author1 = authorManager.Search(search);
            searchvm.Time1 = timeManager.Search(search);
            searchvm.Video1 = videoManager.Search(search);
            searchvm.Goods1 = goodsManager.Search(search);
            searchvm.Post1 = postManager.Search(search);
            searchvm.UserInfo1 = userInfoManager.Search(search);
            return View(searchvm);
        }
        #region 搜索页面
        [HttpPost]
        public ActionResult Index(string search)
        {
            Session["Search"] = search;
            searchvm.Shi1 = shiManager.Search(search);
            searchvm.Ci1 = ciManager.Search(search);
            searchvm.Author1 = authorManager.Search(search);
            searchvm.Time1 = timeManager.Search(search);
            searchvm.Video1 = videoManager.Search(search);
            searchvm.Goods1 = goodsManager.Search(search);
            searchvm.Post1 = postManager.Search(search);
            searchvm.UserInfo1 = userInfoManager.Search(search);
            return View(searchvm);
        }
        #endregion
        
        //#region 原创排行数据获取
        //public ActionResult GetAllSearch(int choose_id, int? page)
        //{
        //    var post = pm.GetAllPostByZan();
        //    ViewBag.Choose_id = choose_id;
        //    if (choose_id == 1)
        //    {
        //        post = pm.GetAllPostByZan();
        //    }
        //    else if (choose_id == 2)
        //    {
        //        post = pm.GetAllPostByCai();
        //    }
        //    else
        //    {
        //        post = pm.GetAllPostByClick();
        //    }
        //    int pageSize = 10;
        //    int pageNumber = (page ?? 1);
        //    return View(post.ToPagedList(pageNumber, pageSize));
        //}
        //#endregion
    }
}