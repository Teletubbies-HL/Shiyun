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
using Shiyun.Models;

namespace Shiyun.Controllers
{
    public class ShiShowController : Controller
    {
        ShiyunEntities db = new ShiyunEntities();
        ShiManager shimanager = new ShiManager();
        AuthorManager authormanager = new AuthorManager();
        TimeManager timemanager = new TimeManager();
        ShiTypeManager shitypemanager = new ShiTypeManager();
        CiManager cimanager = new CiManager();
        CiPaiManager cipaimanager = new CiPaiManager();
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

        #region 诗详情页

        public ActionResult ShiShowShiDetails(int id)
        {
            Session["Shi_id"] = id;
            if (Session["Shi_id"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shis = shimanager.GetShiById(id);
            if (shis == null)
            {
                return HttpNotFound();
            }
            return View(shis);
        }

        #endregion


        #region 词展示

        #region 词展示首页

        public ActionResult CiIndex()
        {
            var citop7 = cimanager.GetCibyTop(7);
            var ciauthor1 = authormanager.whereAuthorById(36);
            var ciauthor2 = authormanager.whereAuthorById(37);
            var ciauthor3 = authormanager.whereAuthorById(38);
            var ciauthor4 = authormanager.whereAuthorById(39);
            var ciauthor5 = authormanager.whereAuthorById(40);
            var ciauthor6 = authormanager.whereAuthorById(27);
            var cipai1 = cipaimanager.whereCiPaiById(1);
            var cipai2 = cipaimanager.whereCiPaiById(2);
            var cipai3 = cipaimanager.whereCiPaiById(3);
            var cipai4 = cipaimanager.whereCiPaiById(4);
            var cipai5 = cipaimanager.whereCiPaiById(5);
            var cipai6 = cipaimanager.whereCiPaiById(6);
            var ci1 = cimanager.GetbyTopandCiPaiId(5, 1);
            var ci2 = cimanager.GetbyTopandCiPaiId(5, 2);
            var ci3 = cimanager.GetbyTopandCiPaiId(5, 3);
            var ci4 = cimanager.GetbyTopandCiPaiId(5, 4);
            var ci5 = cimanager.GetbyTopandCiPaiId(5, 5);
            var ci6 = cimanager.GetbyTopandCiPaiId(5, 6);
            //var ci2 = cimanager.get(2);
            Models.ShiViewModels civm = new Models.ShiViewModels();
            civm.Citop7 = citop7;
            civm.CiAuthor1 = ciauthor1;
            civm.CiAuthor2 = ciauthor2;
            civm.CiAuthor3 = ciauthor3;
            civm.CiAuthor4 = ciauthor4;
            civm.CiAuthor5 = ciauthor5;
            civm.CiAuthor6 = ciauthor6;
            civm.CiPai1 = cipai1;
            civm.CiPai2 = cipai2;
            civm.CiPai3 = cipai3;
            civm.CiPai4 = cipai4;
            civm.CiPai5 = cipai5;
            civm.CiPai6 = cipai6;
            civm.Ci1 = ci1;
            civm.Ci2 = ci2;
            civm.Ci3 = ci3;
            civm.Ci4 = ci4;
            civm.Ci5 = ci5;
            civm.Ci6 = ci6;
            return View(civm);
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
        public ActionResult ShiShowCiDetails(int id)
        {
            Session["Ci_id"] = id;
            if (Session["Ci_id"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cis = cimanager.GetCisById(id);
            if (cis == null)
            {
                return HttpNotFound();
            }
            return View(cis);
        }
        #endregion

        #region 诗类型页面
        public ActionResult ShiShowTypeDetails(int id)
        {
            TypeViewModels typsv = new TypeViewModels();
            ViewBag.ShiType_id = id;
            typsv.Type = shitypemanager.whereShiTypeById(id);
            typsv.AllShi = shitypemanager.GetAllShi(id);
            return View(typsv);
        }
        #endregion

        #region 类型分页
        public ActionResult GetShiTypeShi(int ShiTypeId, int? page)
        {
            ViewBag.ShiType_id = ShiTypeId;
            var stps = shitypemanager.GetAllShi(ShiTypeId);
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(stps.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 作者页面
        public ActionResult ShiShowAuthorDetails(int id)
        {
            ShiViewModels authorsc = new ShiViewModels();
            ViewBag.Author_id = id;
            authorsc.GetAuthorById = authormanager.whereAuthorById(id);
            authorsc.Authors = authormanager.GetAllShi(id);
            authorsc.Authorc = authormanager.GetAllCi(id);
            return View(authorsc);
            //var aus = authormanager.whereAuthorById(AuthorId);
            //if (aus == null)
            //{
            //    return HttpNotFound();
            //}
            //var shici = authormanager.GetbyTopandCiPaiId(40, AuthorId);
            //Models.ShiViewModels shivm = new Models.ShiViewModels();
            //shivm.GetAuthorById = aus;
            //shivm.Authorsc = shici;
            //return View(shivm);
        }
        #endregion

        #region 作者诗作分页页面
        public ActionResult GetAuthorShi(int AuthorId, int? page)
        {
            ViewBag.Author_id = AuthorId;
            var aus = authormanager.GetAllShi(AuthorId);
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(aus.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult GetAuthorCi(int AuthorId, int? page)
        {
            ViewBag.Author_id = AuthorId;
            var auc = authormanager.GetAllCi(AuthorId);
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(auc.ToPagedList(pageNumber, pageSize));
        }

        #endregion

        #region 词牌名页面
        public ActionResult ShiShowCiPaiDetails(int id)
        {
            CiPaiViewModels cipai = new CiPaiViewModels();
            ViewBag.CiPai_id = id;
            cipai.CiPai = cipaimanager.whereCiPaiById(id);
            cipai.AllCi = cipaimanager.GetAllCi(id);
            return View(cipai);
        }
        #region 词牌名分页
        public ActionResult GetCiPaiCi(int CiPaiId, int? page)
        {
            ViewBag.CiPai_id = CiPaiId;
            var cp = cipaimanager.GetAllCi(CiPaiId);
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(cp.ToPagedList(pageNumber, pageSize));
        }
        #endregion
        #endregion
    }
}