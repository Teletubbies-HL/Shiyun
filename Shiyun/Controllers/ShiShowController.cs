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
        AuthorManager authormanager = new AuthorManager();
        TimeManager timemanager = new TimeManager();
        ShiTypeManager shitypemanager = new ShiTypeManager();
        // GET: ShiShow

        #region 诗展示

        #region 诗展示首页
        public ActionResult ShiIndex()
        {
            var shitop8 = shimanager.GetShibyTop(8);
            var shi1 = shimanager.whereShiById(2);
            var shi2 = shimanager.whereShiById(4);
            var shi3 = shimanager.whereShiById(6);
            var shi4 = shimanager.whereShiById(8);
            var shi5 = shimanager.whereShiById(10);
            var shi6 = shimanager.whereShiById(12);
            var shinew22 = shimanager.GetShibyLast(22);
            var shiauthor1 = authormanager.whereAuthorById(62);
            var shiauthor2 = authormanager.whereAuthorById(56);
            var shiauthor3 = authormanager.whereAuthorById(79);
            var shitypetop12 = shitypemanager.GetShiTypebyTop(12);
            var shitimtop11 = timemanager.GetTimebyTop(11);
            Models.ShiViewModels shivm = new Models.ShiViewModels(); 
            shivm.Shitop8 = shitop8;
            shivm.Shi1 = shi1;
            shivm.Shi2 = shi2;
            shivm.Shi3 = shi3;
            shivm.Shi4 = shi4;
            shivm.Shi5 = shi5;
            shivm.Shi6 = shi6;
            shivm.Shinew22 = shinew22;
            shivm.ShiAuthor1 = shiauthor1;
            shivm.ShiAuthor2 = shiauthor2;
            shivm.ShiAuthor3 = shiauthor3;
            shivm.ShiTypetop12 = shitypetop12;
            shivm.ShiTimetop11 = shitimtop11;
            return View(shivm);
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

        public ActionResult ShiShowDetails()
        {
            return View();
        }
        #region 诗详情页

        #endregion
        #endregion


        #region 词展示

        #region 词展示首页

        public ActionResult CiIndex()
        {
            var shitop8 = shimanager.GetShibyTop(8);
            var shi1 = shimanager.whereShiById(2);
            var shi2 = shimanager.whereShiById(4);
            var shi3 = shimanager.whereShiById(6);
            var shi4 = shimanager.whereShiById(8);
            var shi5 = shimanager.whereShiById(10);
            var shi6 = shimanager.whereShiById(12);
            var shinew22 = shimanager.GetShibyLast(22);
            var shiauthor1 = authormanager.whereAuthorById(62);
            var shiauthor2 = authormanager.whereAuthorById(56);
            var shiauthor3 = authormanager.whereAuthorById(79);
            var shitypetop12 = shitypemanager.GetShiTypebyTop(12);
            var shitimtop11 = timemanager.GetTimebyTop(11);
            Models.ShiViewModels shivm = new Models.ShiViewModels();
            shivm.Shitop8 = shitop8;
            shivm.Shi1 = shi1;
            shivm.Shi2 = shi2;
            shivm.Shi3 = shi3;
            shivm.Shi4 = shi4;
            shivm.Shi5 = shi5;
            shivm.Shi6 = shi6;
            shivm.Shinew22 = shinew22;
            shivm.ShiAuthor1 = shiauthor1;
            shivm.ShiAuthor2 = shiauthor2;
            shivm.ShiAuthor3 = shiauthor3;
            shivm.ShiTypetop12 = shitypetop12;
            shivm.ShiTimetop11 = shitimtop11;
            return View(shivm);
        }



        #region 词具体分类展示
        #endregion

        #endregion

        #region 词具体分类展示
        #endregion
        #endregion

        #region 词选择
        #endregion

        #region 词详情
        #endregion


    }
}