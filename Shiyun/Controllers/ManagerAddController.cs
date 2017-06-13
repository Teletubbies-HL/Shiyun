using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using PagedList;
using System.Net;
using System.IO;
using System.Web.Helpers;
using Shiyun.Attributes;
using System.Data.Entity;

namespace Shiyun.Controllers
{
    public class ManagerAddController : Controller
    {
        ShiyunEntities db = new ShiyunEntities();
        TimeManager timemanager = new TimeManager();
        AuthorManager authormanager = new AuthorManager();
        ShiTypeManager shitypemanager = new ShiTypeManager();
        CiPaiManager cipaimanager = new CiPaiManager();
        VideoKManager vk = new VideoKManager();
        VideoManager video = new VideoManager();
        ManagerManager mm = new ManagerManager();
        ShiCommentManager sc = new ShiCommentManager();
        CiCommentManager cc = new CiCommentManager();

        
        #region ----年代表Time后台----

        #region ---诗年代表列表展示

        public ActionResult TimeIndex()
        {
            var time = timemanager.GetTime();
            return View(time);
        }
        #endregion

        #region ---年代表添加---
        #region //添加年代的Get方法
        public ActionResult TimeCreate()
        {           
            return View("TimeCreate");
        }
        #endregion
        #region//添加年代的POST方法
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]             
        public ActionResult TimeCreate([Bind(Include = "Time_id,TimeName,TimeImage,TimeJieshao，AddTime")]Time time)
        {
            try
            {
                HttpPostedFileBase timeimage = Request.Files["TimeImage"];

                string filePath = timeimage.FileName;
                string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                string serverpath = Server.MapPath(@"\Images\Time\") + filename;
                string relativepath = @"/Images/Time/" + filename;
                timeimage.SaveAs(serverpath);
                time.TimeImage = relativepath;
                timemanager.AddTime(time);
                db.SaveChanges();
                return RedirectToAction("TimeIndex");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }         
            return View("TimeCreate", time);
        }
        #endregion
        #endregion

        #region ---年代表更新---
        public ActionResult TimeEdit()
        {
            return View();
        }
        #endregion

        #region ---年代表删除--
        public ActionResult TimeDelete()
        {
            return View();
        }
        #endregion
        #endregion

        #region ----作者表Author后台----

        #region ---作者表列表展示

        public ActionResult AuthorIndex()
        {
            var author = authormanager.GetAuthor();
            return View(author);
        }
        #endregion

        #region ---作者表添加---
        #region //添加作者的Get方法
        public ActionResult AuthorCreate()
        {
            ViewBag.Time_id = new SelectList(db.Time, "Time_id", "TimeName");
            return View("AuthorCreate");
        }
        #endregion
        #region//添加作者的POST方法
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AuthorCreate([Bind(Include = "Author_id,AuthorName,AuthorImage,Jieshao,Time_id")]Author author)
        {
            try
            {
                HttpPostedFileBase authorimage = Request.Files["AuthorImage"];

                string filePath = authorimage.FileName;
                string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                string serverpath = Server.MapPath(@"\Images\Author\") + filename;
                string relativepath = @"/Images/Author/" + filename;
                authorimage.SaveAs(serverpath);
                author.AuthorImage = relativepath;
                authormanager.AddAuthor(author);
                db.SaveChanges();
                return RedirectToAction("AuthorIndex");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            ViewBag.Time_id = new SelectList(db.Time, "Time_id", "TimeName", author.Time_id);
            return View("AuthorCreate", author);
        }
        #endregion    
        #endregion

        #region ---作者表更新---
        public ActionResult AuthorEdit()
        {
            return View();
        }
        #endregion

        #region ---作者表删除--
        public ActionResult AuthorDelete()
        {
            return View();
        }
        #endregion
        #endregion

        #region ----类型表ShiType后台----

        #region ---类型表列表展示

        public ActionResult TypeIndex()
        {
            var type = shitypemanager.GetShiType();
            return View(type);
        }
        #endregion

        #region ---类型表添加---
        #region //添加作者的Get方法
        public ActionResult TypeCreate()
        {
            return View("TypeCreate");
        }
        #endregion
        #region//添加作者的POST方法
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult TypeCreate([Bind(Include = "ShiType_id,ShiTypeName,ShiTypeJieshao,ShiTypeImage")]ShiType shitype)
        {
            //if (ModelState.IsValid)
            //{
            //    shitypemanager.AddShiType(shitype);
            //    return RedirectToAction("TypeIndex");
            //}                                
            //return View("TypeCreate", shitype);
            try
            {
                HttpPostedFileBase shitypeimage = Request.Files["ShiTypeImage"];

                string filePath = shitypeimage.FileName;
                string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                string serverpath = Server.MapPath(@"\Images\ShiType\") + filename;
                string relativepath = @"/Images/ShiType/" + filename;
                shitypeimage.SaveAs(serverpath);
                shitype.ShiTypeImage = relativepath;
                shitypemanager.AddShiType(shitype);
                db.SaveChanges();
                return RedirectToAction("TypeIndex");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return View("TypeCreate", shitype);
        }
        #endregion    
        #endregion

        #region ---类型表更新---
        public ActionResult TypeSEdit()
        {
            return View();
        }
        #endregion

        #region ---类型表删除---
        public ActionResult TypeSDelete()
        {
            return View();
        }
        #endregion
        #endregion

        #region ----词牌名表CiPai后台----

        #region ---词牌名表列表展示

        public ActionResult CiPaiIndex()
        {
            var cipai = cipaimanager.GetCiPai();
            return View(cipai);
        }
        #endregion

        #region ---词牌名表添加---
        #region //添加词牌名的Get方法
        public ActionResult CiPaiCreate()
        {
            return View("CiPaiCreate");
        }
        #endregion
        #region//添加词牌名的POST方法
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult CiPaiCreate([Bind(Include = "CiPai_id,CiPaiName,CiPaiJieshao，CiPaiImage")]CiPai cipai)
        {
           
            try
            {
                HttpPostedFileBase cipaiimage = Request.Files["CiPaiImage"];

                string filePath = cipaiimage.FileName;
                string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                string serverpath = Server.MapPath(@"\Images\CiPai\") + filename;
                string relativepath = @"/Images/CiPai/" + filename;
                cipaiimage.SaveAs(serverpath);
                cipai.CiPaiImage = relativepath;
                cipaimanager.AddCiPai(cipai);
                db.SaveChanges();
                return RedirectToAction("CiPaiIndex");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return View("CiPaiCreate", cipai);
        }
        #endregion          
        #endregion

        #region ---词牌名表更新---
        public ActionResult CiPaiEdit()
        {
            return View();
        }
        #endregion

        #region ---词牌名表更新---
        public ActionResult CiPaiDelete()
        {
            return View();
        }
        #endregion
        #endregion

        #region 视频后台
        #region 视频类别添加
        public ActionResult VideoKCreate()
        {
            return View("VideoKCreate");
        }
        #region//添加视频类别的POST方法
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult VideoKCreate([Bind(Include = "VideoK_id,VideoKName,Cover,VideoDetails,VideoJianjie,Source,AddTime")]VideoK videok)
        {
            videok.AddTime = System.DateTime.Now;
            try
            {
                HttpPostedFileBase videokcover = Request.Files["Cover"];

                string filePath = videokcover.FileName;
                string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                string serverpath = Server.MapPath(@"\Images\VideoK\") + filename;
                string relativepath = @"/Images/VideoK/" + filename;
                videokcover.SaveAs(serverpath);
                videok.Cover = relativepath;
                vk.AddVideoK(videok);

                db.SaveChanges();
                return RedirectToAction("TypeIndex");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return View("VideoKCreate", videok);
        }

        #endregion
        #endregion
        #region 视频类别列表
        public ActionResult VideoKIndex(int? page)
        {
            var shi =vk.GetVideoK();
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(shi.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 视频添加
        #region//添加视频的Get方法
        public ActionResult VideoCreate()
        {
            
            ViewBag.VideoK_id = new SelectList(db.VideoK, "VideoK_id", "VideoKName");
            return View("VideoCreate");
        }
        #endregion      
        #region //添加视频的POST方法
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult VideoCreate(Video v)
        {
            HttpPostedFileBase videocover = Request.Files["Cover"];
            HttpPostedFileBase videurl = Request.Files["VideoURL"];
            v.AddTime = System.DateTime.Now;
            try
            {

                if (videocover != null)
                {
                    string filePath = videocover.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\Images\Video\") + filename;
                    string relativepath = @"/Images/Video/" + filename;
                    videocover.SaveAs(serverpath);
                    v.Cover = relativepath;
                }
                else
                {
                    return Content("<script>;alert('请先上传图片！');history.go(-1)</script>");
                }
                if (videurl != null)
                {
                    string filePath = videurl.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\Video\") + filename;
                    string relativepath = @"/Video/" + filename;
                    videurl.SaveAs(serverpath);
                    v.VideoURL = relativepath;
                }
                video.AddVideo(v);
               
                db.SaveChanges();
                return RedirectToAction("CiIndex");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            ViewBag.VideoK_id = new SelectList(db.VideoK, "VideoK_id", "VideoKName", v.VideoK_id);
            return View("CiCreate", v);
        }
        #endregion
        #endregion
        #region 视频列表
        public ActionResult VideoIndex(int? page)
        {
            var shi = video.GetVideo();
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(shi.ToPagedList(pageNumber, pageSize));
        }
        #endregion
        #endregion

        #region 后台附页
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult main()
        {
            return View();
        }
        #endregion      

        #region 后台主页
        public ActionResult menu()
        {
            string uid = Session["Manager_id"].ToString();
            if (uid != null)
            {
                return View();
            }
            else
            {
                return Content("<script>alert('您尚未登陆，请登陆');history.go(-1);</script>");
            }
            
        }
        #endregion

        #region 后台登录
        [HttpPost]
        public string Login([Bind(Include = "Manager_id,ManagerPass")]string Manager_id, string ManagerPass)
        {
            try
            {
                var users = mm.Denglu(Manager_id, ManagerPass);
                if (users != null)
                {
                    //保存到Session HttpContext.
                    Session["Manager_id"] = Manager_id;
                    Session["ManagerName"] = mm.GetManagersById(Manager_id).ManagerName;
                    string data = "登录成功";
                    return data;
                }
                else
                {
                    string data = "登录失败";
                    return data;
                }
            }
            catch (Exception ex)
            {
                string data = "错误";
                return data;
            }
        }
        #endregion

        #region 后台注销
        [HttpPost]
        public string Zhuxiao()
        {
            //保存到Session HttpContext.
            Session["Manager_id"] = null;
            string A = "a";
            return A;
        }
        #endregion

        #region 诗回复列表
        public ActionResult ScIndex(int? page)
        {
            var goods = sc.GetShiComment();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(goods.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 词回复列表
        public ActionResult CcIndex(int? page)
        {
            var goods = cc.GetCiComment();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(goods.ToPagedList(pageNumber, pageSize));
        }
        #endregion

       

    }
}