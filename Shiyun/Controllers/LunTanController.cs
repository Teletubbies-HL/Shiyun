using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using Shiyun.Models;
using System.Net;
using PagedList;
using System.Collections;
using Shiyun.Attributes;

namespace Shiyun.Controllers
{
    public class LunTanController : Controller
    {
        // GET: LunTan
        ShiyunEntities db = new ShiyunEntities();
        LunTanManager ltm = new LunTanManager();
        PostManager pm = new PostManager();
        PostReplyManager pr = new PostReplyManager();
        #region  论坛主页
        public ActionResult Index()
        {
            LuntanIndex luntanIndex = new LuntanIndex();
            luntanIndex.FenLei = ltm.GetFenlei(); //导航分类
            luntanIndex.HotPost = ltm.GetHostPost();//热帖
            luntanIndex.ZongheTaolun = ltm.GetZongheTaolun(); //综合讨论
            luntanIndex.PaiHang = ltm.GetPaiHang(); //排名
            return View(luntanIndex);
        }
        #endregion 
        #region 原创页面
        public ActionResult YuanChuang(int luntanId)
        {
            LuntanIndex luntanIndex = new LuntanIndex();
            ViewBag.LunTan_id = luntanId;
            luntanIndex.FenLei = ltm.GetFenlei(); //导航分类
            luntanIndex.YuanChuangZd = ltm.GetYuanChuangZd(1); //原创置顶
            luntanIndex.LuntanName = ltm.GetLuntanName(luntanId); //论坛名称
            luntanIndex.PaiHang = ltm.GetPaiHang(); //排名
            luntanIndex.AllPost = ltm.GetAllPost(luntanId); //原创所有帖子     
            return View(luntanIndex);
        }
        #endregion
        #region 原创分页数据获取
        public ActionResult GetAllPost(int luntanId, int? page)
        {
            ViewBag.LunTan_id = luntanId;
            var post = ltm.GetAllPost(luntanId);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(post.ToPagedList(pageNumber, pageSize));
        }
        #endregion
        #region 发帖Get页面
        [Login]
        public ActionResult PostSend(int luntanId)
        {
            LuntanIndex luntanIndex = new LuntanIndex();
            luntanIndex.FenLei = ltm.GetFenlei(); //导航分类
            //ViewBag.LunTan_id = new SelectList(db.LunTan, "LunTan_id", "LunTanName");
            luntanIndex.List1 = new SelectList(db.LunTan, "LunTan_id", "LunTanName");//下拉列表数据绑定
            ViewBag.LunTan_id = luntanId;
            //luntanIndex.LuntanId = luntanId;
            return View(luntanIndex);
        }
        #endregion
        # region 发帖Post页面
        [HttpPost]
        [ValidateInput(false)]  //富文本编辑器使用
        [ValidateAntiForgeryToken]
        //[ValidateAntiForgeryToken]特性用来防止伪造的跨站请求，配合表单中的@Html.AntiForgeryToken()使用
        //对数据进行增删改时要防止csrf攻击！
        //该特性表示检测服务器请求是否被篡改。注意：该特性只能用于post请求，get请求无效。
        [Login]
        [MultiButton("postt")]   //通过name来选择post方法
        public ActionResult PostSend(Post post)
        {
            HttpPostedFileBase ltmp3 = Request.Files["luntanmp3"];
            try
            {
                if (ltmp3 != null)
                {
                    string filePath = ltmp3.FileName;
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    if (filename.Length >= 195)
                    {
                        return Content("<script>;alert('文件名不超过170个字符！');history.go(-1)</script>");
                    }
                    else
                    {
                        string serverpath = Server.MapPath(@"\MP3\luntan\") + filename;
                        string relativepath = @"/MP3/luntan/" + filename;
                        ltmp3.SaveAs(serverpath);
                        post.Mp3_Url = relativepath;
                    }
                }
                else
                {
                    return Content("<script>;alert('请先上传音频！');history.go(-1)</script>");
                }

                if (ModelState.IsValid)
                {
                    post.AddTime = System.DateTime.Now;
                    post.Post_draft = 0;
                    post.Users_id = Session["Users_id"].ToString();
                    pm.AddPost(post);
                    //db.Post.Add(post);
                    //db.SaveChanges();
                    //return RedirectToAction("Index");
                    return Content("<script>;alert('发布成功！');window.history.go(-2);window.location.reload();</script>");
                }
                else
                {
                    return Content("<script>;alert('发布失败！');history.go(-1)</script>");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            ViewBag.LunTan_id = new SelectList(db.LunTan, "LunTan_id", "LunTanName", post.LunTan_id);
            return View();
        }
        #endregion
        #region 发帖Save页面
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [Login]
        [MultiButton("savee")]
        public ActionResult PostSend(Post post, int? postdraft)
        {
            HttpPostedFileBase ltmp3 = Request.Files["luntanmp3"];
            try
            {
                if (ltmp3 != null)
                {
                    string filePath = ltmp3.FileName;
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    if (filename.Length >= 195)
                    {
                        return Content("<script>;alert('文件名不超过170个字符！');history.go(-1)</script>");
                    }
                    string serverpath = Server.MapPath(@"\MP3\luntan\") + filename;
                    string relativepath = @"/MP3/luntan/" + filename;
                    ltmp3.SaveAs(serverpath);
                    post.Mp3_Url = relativepath;
                }
                else
                {
                    return Content("<script>;alert('请先上传音频！');history.go(-1)</script>");
                }

                if (ModelState.IsValid)
                {
                    post.AddTime = System.DateTime.Now;
                    post.Post_draft = 1;
                    post.Users_id = Session["Users_id"].ToString();
                    pm.AddPost(post);
                    return Content("<script>;alert('存为草稿成功！');window.history.go(-2);window.location.reload();</script>");
                }
                else
                {
                    return Content("<script>;alert('存为草稿失败！');history.go(-1)</script>");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            //ViewBag.LunTan_id = new SelectList(db.LunTan, "LunTan_id", "LunTanName", post.LunTan_id);
            return View();
        }
        #endregion
        #region  帖子详情页面
        public ActionResult PostDetails(int luntanId ,int postId)
        {
            LuntanIndex luntanIndex = new LuntanIndex();
            ViewBag.LunTan_id = luntanId;
            ViewBag.Post_id = postId;
            luntanIndex.FenLei = ltm.GetFenlei(); //导航分类 
            luntanIndex.LuntanName = ltm.GetLuntanName(luntanId); //论坛名称       
            luntanIndex.PostDetails = pm.GetPostDetails(postId);//帖子详情
            luntanIndex.AllPostReply = pr.GetPostReply(postId);
            return View(luntanIndex);
        }
        #endregion
        #region 帖子评论数据获取
        public ActionResult GetAllPostReply(int postId, int? page)
        {
            var postreply = pr.GetPostReply(postId);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(postreply.ToPagedList(pageNumber, pageSize));
        }
        #endregion
        #region  保存评论
        [HttpPost]
        [ValidateInput(false)]  //富文本编辑器使用
        [ValidateAntiForgeryToken]
        [Login]
        public ActionResult Pinglun(PostReply postReply)
        {
           
            if (ModelState.IsValid)
                {
                    postReply.ReplyTime = System.DateTime.Now;
                    postReply.Users_id = Session["Users_id"].ToString();              
                    pr.AddPostReply(postReply);
                    return Content("<script>;alert('发布成功！');window.history.go(-1);window.location.reload();</script>");
                }
                else
                {
                    return Content("<script>;alert('发布失败！');history.go(-1)</script>");
                }        
        }
        #endregion
    }
}