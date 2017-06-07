using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;
using Models;

using Shiyun.Models;
using BLL;

namespace Shiyun.Controllers
{
    public class ShiCiController : Controller
    {
        // GET: ShiCi
        ShiyunEntities db = new ShiyunEntities();
        ShiManager shi = new ShiManager();
        ShiTypeManager shitype = new ShiTypeManager();      
        CiPaiManager ap = new CiPaiManager();
        CiManager ci = new CiManager();
        TimeManager ta = new TimeManager();
        AuthorManager au = new AuthorManager();
        #region 第一种方法
        public ActionResult Index()
        {
            var section = shi.GetShi();
            var redsopt = shitype.GetShiType();
            Models.TypeViewModels shivm = new Models.TypeViewModels();           
            shivm.Type = redsopt;
            shivm.TypeShi = section;
            return View(shivm);
        }

        [HttpGet]
        public ActionResult Redid(int? page, int? sectionid, string search)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);
            var redsopt = shi.GetShi();
            if (!String.IsNullOrEmpty(search))
            {
                redsopt = redsopt.Where(a => a.ShiType.ShiTypeName.Contains(search));
            }
            if (sectionid >= 1)
            {
                redsopt = redsopt.Where(a => a.ShiType_id == sectionid);
            }


            ViewBag.id = sectionid;
            if (Request.IsAjaxRequest())

            {
                return PartialView("Redid", redsopt.OrderBy(a => a.ShiType_id).ToPagedList(pageNum, pageSize));
            }
            else {
                return View("Redid", redsopt.OrderBy(a => a.ShiType_id).ToPagedList(pageNum, pageSize));
            }
        }
        #endregion

        #region 诗 第二种方法
        public PartialViewResult ShiIndex(String genreInfoFrom, string currentFilter, int? page)
        {
            var sort1 = db.ShiType.ToList();

            //var sort2 = db.Sort.ToList();

            //var foods = from m in db.Shi.OrderByDescending(p => p.Shi_id)

            //            select m;
            var foods = shi.GetShi();


            if (genreInfoFrom != null)
            {
                page = 1;
            }
            else
            {
                genreInfoFrom = currentFilter;
            }

            ViewBag.CurrentFilter = genreInfoFrom;


            //if (SortInfoFrom != null)
            //{
            //    page = 1;
            //}
            //else
            //{
            //    SortInfoFrom = currentFilter;
            //}

            //ViewBag.CurrentFilter = SortInfoFrom;

            if (!String.IsNullOrEmpty(genreInfoFrom))
            {

                foods = foods.Where(x => x.ShiType.ShiTypeName == genreInfoFrom);

            }

            //if (!String.IsNullOrEmpty(SortInfoFrom))
            //{
            //    foods = foods.Where(x => x.Sort.Name == SortInfoFrom);
            //}

            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var menu = new TypeViewModels()
            {

                Type = sort1,
                //Sort2 = sort2,
                TypeShi = foods.ToPagedList(pageNumber, pageSize),
            };


            //return View(menu);
            return PartialView("ShiIndex", menu);

        }
        #endregion

        #region 年代方法
        public PartialViewResult TimeIndex(String genreInfoFrom, string currentFilter, int? page)
        {
            var sort1 = db.Time.ToList();

            var foods = au.GetAuthor();


            if (genreInfoFrom != null)
            {
                page = 1;
            }
            else
            {
                genreInfoFrom = currentFilter;
            }

            ViewBag.CurrentFilter = genreInfoFrom;


            if (!String.IsNullOrEmpty(genreInfoFrom))
            {

                foods = foods.Where(x => x.Time.TimeName == genreInfoFrom);

            }



            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var menu = new TimeViewModels()
            {

                Time = sort1,
                TimeAuthor = foods.ToPagedList(pageNumber, pageSize),
            };


            //return View(menu);
            return PartialView("TimeIndex", menu);

        }
        #endregion

        #region 词牌方法
        public PartialViewResult CiPaiIndex(String genreInfoFrom, string currentFilter, int? page)
        {
            var sort1 = db.CiPai.ToList();

            var foods = ci.GetCi();


            if (genreInfoFrom != null)
            {
                page = 1;
            }
            else
            {
                genreInfoFrom = currentFilter;
            }

            ViewBag.CurrentFilter = genreInfoFrom;


            if (!String.IsNullOrEmpty(genreInfoFrom))
            {

                foods = foods.Where(x => x.CiPai.CiPaiName == genreInfoFrom);

            }



            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var menu = new CiPaiViewModels()
            {

                CiPai = sort1,
                CiPaiCi = foods.ToPagedList(pageNumber, pageSize),
            };


            //return View(menu);
            return PartialView("CiPaiIndex", menu);

        }
        #endregion
    }
}