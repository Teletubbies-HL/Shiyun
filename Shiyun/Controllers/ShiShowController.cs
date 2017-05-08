using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using System.Net;
using PagedList;
using System.IO;
using System.Web.Helpers;

namespace Shiyun.Controllers
{
    public class ShiShowController : Controller
    {
        ShiyunEntities db = new ShiyunEntities();
        ShiManager shimanager = new ShiManager();
        // GET: ShiShow

        #region 诗展示

        #region 诗展示首页
        public ActionResult ShiIndex()
        {
            var shitop8 = shimanager.GetShibyTop(8);
            Models.ShiViewModels shivm = new Models.ShiViewModels();
            shivm.Shitop8 = shitop8;
            return View();
        }
        #endregion

        #region 诗具体分类选择页面
        public ActionResult ShiKIndex()
        {
            return View();
        }
        #endregion
        #endregion

        #region 选择页

        #region 诗作者页面
        public ActionResult ShiAuthorDetails()
        {
            return View();
        }
        #endregion

        #region 诗年代页面
        public ActionResult ShiTimeDetails()
        {
            return View();
        }
        #endregion

        #region 诗类型页面
        public ActionResult ShiLeiDetails()
        {
            return View();
        }
        #endregion
        #endregion

        #region 详情页

        #region 诗详情页

        #endregion
        #endregion

    }
}