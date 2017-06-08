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

        #region 诗 第一种方法
        public PartialViewResult ShiIndex(String genreInfoFrom, string currentFilter, int? page)
        {
            var sort1 = db.ShiType.ToList();
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
            if (!String.IsNullOrEmpty(genreInfoFrom))
            {
                foods = foods.Where(x => x.ShiType.ShiTypeName == genreInfoFrom);
            }
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            var menu = new TypeViewModels()
            {
                Type = sort1,
                TypeShi = foods.ToPagedList(pageNumber, pageSize),
            };
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