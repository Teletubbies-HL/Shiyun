using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using System.Net;
using System.IO;
using System.Web.Helpers;
using PagedList;
using System.Web.UI;

namespace Shiyun.Controllers
{
    public class ShiController : Controller
    {
        // GET: Shi
        
        ShiyunEntities db = new ShiyunEntities();
        ShiManager shimanager = new ShiManager();
        CiManager cimanager = new CiManager();
        TimeManager timemanager = new TimeManager();
        AuthorManager authormanager = new AuthorManager();
        #region 朝代诗人联动
        public JsonResult GetTime()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            //var times = Service.GetTime();
            var times = timemanager.GetTime();
            foreach (Time t in times)
            {
                items.Add(new SelectListItem()
                {
                    Text = t.TimeName,
                    Value = Convert.ToString(t.Time_id)
                });
            }
            if (!items.Count.Equals(0))
            {
                items.Insert(0, new SelectListItem() { Text = "请选择", Value = "" });
            }
            return Json(items, JsonRequestBehavior.AllowGet);
            //return Json(items, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAuthor(string id)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(id))
            {
                //var authors = Service.GetAuthorByTime(int.Parse(id));
                var authors = authormanager.GetAuthorByTimeId(int.Parse(id));
                foreach (Author a in authors)
                {
                    items.Add(new SelectListItem()
                    {
                        Text = string.Concat(a.AuthorName),
                        Value = a.Author_id.ToString()
                    });
                }
                if (!items.Count.Equals(0))
                {
                    items.Insert(0, new SelectListItem() { Text = "请选择", Value = "" });
                }
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region 诗列表
        public ActionResult Index(int?page)
        {
            var shi = shimanager.GetShi();
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(shi.ToPagedList(pageNumber, pageSize));
            //return View(shi);
        }
        #endregion

        #region 添加诗
        #region//添加诗的Get方法
        public ActionResult ShiCreate()
        {
            //存储在ViewBag.CategoryId属性中的分类数据是为了让视图中的DropDownList辅助方法检索
            //SelectList类用于表示构建下拉列表需要的数据，构造函数的第1个参数指定了将要放在列表中的项，
            //第2个参数是一个属性名称，该属性包含当用户选择一个指定项时使用的键值，
            //第3个参数是每一项要显示的文本，第4个参数包含了最初选定项的值。
            ViewBag.Author_id = new SelectList(db.Author, "Author_id", "AuthorName");
            ViewBag.Time_id = new SelectList(db.Time, "Time_id", "TimeName");
            ViewBag.ShiType_id = new SelectList(db.ShiType, "ShiType_id", "ShiTypeName");
            
            return View("ShiCreate");
        }
        #endregion
        // POST: StoreManager/Create
        #region //添加诗的POST方法
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        //[ValidateAntiForgeryToken]特性用来防止伪造的跨站请求，配合表单中的@Html.AntiForgeryToken()使用
        //对数据进行增删改时要防止csrf攻击！
        //该特性表示检测服务器请求是否被篡改。注意：该特性只能用于post请求，get请求无效。
        //public ActionResult GoodsCreate([Bind(Include = "Goods_id,GoodsName,GoodsImage,GoodsJianjie,GoodsDetails,AddTime,Price,Count,GoodsK_id")]Goods goods)
        public ActionResult ShiCreate(Shi shi)
        {

            HttpPostedFileBase postimage1 = Request.Files["ShiImage"];
            HttpPostedFileBase postyuyin = Request.Files["ShiYuying"];
            //[Bind(Include = "Goods_id,GoodsName,GoodsImage,GoodsJianjie,GoodsDetails,AddTime,Price,Count,GoodsK_id")]
            try
            {
                //HttpPostedFileBase postimage1 = Request.Files["ShiImage"];

                if (postimage1 != null)
                {
                    string filePath = postimage1.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\Images\shi\") + filename;
                    string relativepath = @"/Images/shi/" + filename;
                    postimage1.SaveAs(serverpath);
                    shi.ShiImage = relativepath;
                }
                else
                {
                    return Content("<script>;alert('请先上传图片！');history.go(-1)</script>");
                }
                if (postyuyin != null)
                {
                    string filePath = postyuyin.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\MP3\shi\") + filename;
                    string relativepath = @"/MP3/shi/" + filename;
                    postyuyin.SaveAs(serverpath);
                    shi.ShiYuying = relativepath;
                }
                //else
                //{
                //    return Content("<script>;alert('请先上传音频！');history.go(-1)</script>");
                //}
                shimanager.AddShi(shi);
                shi.AddTime = System.DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            ViewBag.Author_id = new SelectList(db.Author, "Author_id", "AuthorName", shi.Author_id);
            ViewBag.Time_id = new SelectList(db.Time, "Time_id", "TimeName", shi.Time_id);
            ViewBag.ShiType_id = new SelectList(db.ShiType, "ShiType_id", "ShiTypeName", shi.ShiType_id);
          
            return View("ShiCreate", shi);
        }
        #endregion       
        #endregion

        #region 更新诗
        #region//更新诗的Get方法
        public ActionResult ShiEdit(int? id)
        {
            HttpPostedFileBase postimage1 = Request.Files["ShiImage"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shi shi = shimanager.GetShiById(id);
            if (shi == null)
            {
                return HttpNotFound();
            }
            if (postimage1 != null)
            {
                string filePath = postimage1.FileName;
                string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                string serverpath = Server.MapPath(@"\Images\shi\") + filename;
                string relativepath = @"/Images/shi/" + filename;
                postimage1.SaveAs(serverpath);
                shi.ShiImage = relativepath;
            }
            else
            {
                return Content("<script>;alert('请先上传图片！');history.go(-1)</script>");
            }

            ViewBag.Author_id = new SelectList(db.Author, "Author_id", "AuthorName", shi.Author_id);
            ViewBag.ShiType_id = new SelectList(db.ShiType, "ShiType_id", "ShiTypeName", shi.ShiType_id);
            ViewBag.Time_id = new SelectList(db.Time, "Time_id", "TimeName", shi.Time_id);
            return View(shi);
        }
        #endregion
        // POST: StoreManager/Edit/5
        #region//编辑诗的POST方法
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        //[ValidateAntiForgeryToken]特性用来防止伪造的跨站请求，配合表单中的@Html.AntiForgeryToken()使用
        //对数据进行增删改时要防止csrf攻击！
        //该特性表示检测服务器请求是否被篡改。注意：该特性只能用于post请求，get请求无效。
        public ActionResult ShiEdit( Shi shi)
        {
            //[Bind(Include = "Goods_id,GoodsName,GoodsImage,GoodsJianjie,GoodsDetails,AddTime,Price,Count,GoodsK_id")]
            //使用Bind属性的目的是限制用户在提交form表单时使用合适且正确的值。当我们提交一个表单时，就会检查每一个实体上绑定的特性。
            //Bind属性是一个重要的安全机制，可以防止黑客攻击。
            if (ModelState.IsValid)
            {
                shimanager.EditShi(shi);
                return RedirectToAction("Index");
            }
            ViewBag.Author_id = new SelectList(db.Author, "Author_id", "AuthorName", shi.Author_id);
            ViewBag.ShiType_id = new SelectList(db.ShiType, "ShiType_id", "ShiTypeName", shi.ShiType_id);
            ViewBag.Time_id = new SelectList(db.Time, "Time_id", "TimeName", shi.Time_id);

            return View(shi);
        }
        #endregion
        #endregion

        #region 删除诗
        //删除给定的id的诗
        public ActionResult ShiDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shi  shi = shimanager.GetShiById(id);
            if (shi == null)
            {
                return HttpNotFound();
            }
            return View(shi);
        }
        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        ////[ValidateAntiForgeryToken]特性用来防止伪造的跨站请求，配合表单中的@Html.AntiForgeryToken()使用
        ////对数据进行增删改时要防止csrf攻击！
        ////该特性表示检测服务器请求是否被篡改。注意：该特性只能用于post请求，get请求无效。
        public ActionResult DeleteConfirmed(int id)
        {
            Shi shi = shimanager.GetShiById(id);
            int shiid = shi.Shi_id;
            var shicomment = shimanager.GetShiCommentByShiId(shiid);
            if (shicomment.Count() > 0)
            {
                shimanager.RemoveRangeShiComment(shicomment);
            }
           
            shimanager.RemoveShi(shi);
            return RedirectToAction("Index");
        }
        #endregion
       

        #region 词列表
        public ActionResult CiIndex(int? page)
        {
            var ci = cimanager.GetCi();
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(ci.ToPagedList(pageNumber, pageSize));
            
        }
        #endregion

        #region 添加词
        #region//添加词的Get方法
        public ActionResult CiCreate()
        {
            //存储在ViewBag.CategoryId属性中的分类数据是为了让视图中的DropDownList辅助方法检索
            //SelectList类用于表示构建下拉列表需要的数据，构造函数的第1个参数指定了将要放在列表中的项，
            //第2个参数是一个属性名称，该属性包含当用户选择一个指定项时使用的键值，
            //第3个参数是每一项要显示的文本，第4个参数包含了最初选定项的值。
            ViewBag.Author_id = new SelectList(db.Author, "Author_id", "AuthorName");           
            ViewBag.Time_id = new SelectList(db.Time, "Time_id", "TimeName");
            ViewBag.CiPai_id = new SelectList(db.CiPai, "CiPai_id", "CiPaiName");
            return View("CiCreate");
        }
        #endregion
        // POST: StoreManager/Create
        #region //添加词的POST方法
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        //[ValidateAntiForgeryToken]特性用来防止伪造的跨站请求，配合表单中的@Html.AntiForgeryToken()使用
        //对数据进行增删改时要防止csrf攻击！
        //该特性表示检测服务器请求是否被篡改。注意：该特性只能用于post请求，get请求无效。
        //public ActionResult GoodsCreate([Bind(Include = "Goods_id,GoodsName,GoodsImage,GoodsJianjie,GoodsDetails,AddTime,Price,Count,GoodsK_id")]Goods goods)
        public ActionResult CiCreate(Ci ci)
        {
            HttpPostedFileBase postimage1 = Request.Files["CiImage"];
            HttpPostedFileBase postyuyin = Request.Files["CiYuying"];
            //[Bind(Include = "Goods_id,GoodsName,GoodsImage,GoodsJianjie,GoodsDetails,AddTime,Price,Count,GoodsK_id")]
            try
            {
                //HttpPostedFileBase postimage1 = Request.Files["ShiImage"];

                if (postimage1 != null)
                {
                    string filePath = postimage1.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\Images\Ci\") + filename;
                    string relativepath = @"/Images/Ci/" + filename;
                    postimage1.SaveAs(serverpath);
                    ci.CiImage = relativepath;
                }
                else
                {
                    return Content("<script>;alert('请先上传图片！');history.go(-1)</script>");
                }
                if (postyuyin != null)
                {
                    string filePath = postyuyin.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\MP3\ci\") + filename;
                    string relativepath = @"/MP3/ci/" + filename;
                    postyuyin.SaveAs(serverpath);
                    ci.CiYuying = relativepath;
                }
                //else
                //{
                //    return Content("<script>;alert('请先上传音频！');history.go(-1)</script>");
                //}
                cimanager.AddCi(ci);
                ci.AddTime = System.DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("CiIndex");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            ViewBag.Author_id = new SelectList(db.Author, "Author_id", "AuthorName", ci.Author_id);
            ViewBag.Time_id = new SelectList(db.Time, "Time_id", "TimeName", ci.Time_id);
            ViewBag.CiPai_id = new SelectList(db.CiPai, "CiPai_id", "CiPaiName", ci.Cipai_id);
            return View("CiCreate", ci);
        }
        #endregion
        #endregion

        #region 诗按类型分页
        public ActionResult ShiIndex(String genreInfoFrom, string currentFilter, int? page)
        {
            //var foods = from m in db.Shi.OrderByDescending(p => p.Shi_id)

            //            select m;
            var foods = shimanager.GetShi();


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

            

            int pageSize = 18;
            int pageNumber = (page ?? 1);

            return View(foods.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 按年代分
        public ActionResult TimeIndex(String genreInfoFrom, string currentFilter, int? page)
        {
            var foods = authormanager.GetAuthor();


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



            int pageSize = 18;
            int pageNumber = (page ?? 1);

            return View(foods.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 按词牌名分
        public ActionResult CiPaiIndex(String genreInfoFrom, string currentFilter, int? page)
        {
            var foods = cimanager.GetCi();


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



            int pageSize = 18;
            int pageNumber = (page ?? 1);

            return View(foods.ToPagedList(pageNumber, pageSize));
        }
        #endregion
    }
}