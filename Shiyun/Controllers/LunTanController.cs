using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using Shiyun.Models;
using System.Collections;

namespace Shiyun.Controllers
{
    public class LunTanController : Controller
    {
        // GET: LunTan
        ShiyunEntities db = new ShiyunEntities();
        LunTanManager ltm = new LunTanManager();
        PostManager pm = new PostManager();
        public ActionResult Index()
        {
            LuntanIndex luntanIndex = new LuntanIndex();
            luntanIndex.FenLei = ltm.GetFenlei(); //导航分类
            luntanIndex.HotPost = ltm.GetHostPost();//热帖
            luntanIndex.ZongheTaolun = ltm.GetZongheTaolun(); //综合讨论
            luntanIndex.PaiHang = ltm.GetPaiHang(); //排名
            return View(luntanIndex);
        }
        public ActionResult YuanChuang(int luntanId)
        {
            LuntanIndex luntanIndex = new LuntanIndex();
            luntanIndex.FenLei = ltm.GetFenlei(); //导航分类
            luntanIndex.YuanChuangZd = ltm.GetYuanChuangZd(1); //原创置顶
            luntanIndex.LuntanName = ltm.GetLuntanName(luntanId); //论坛名称
            luntanIndex.AllPost = ltm.GetAllPost(luntanId); //原创所有帖子          
            return View(luntanIndex);
        }
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

        [HttpPost]
        [ValidateInput(false)]  //富文本编辑器使用
        [ValidateAntiForgeryToken]
        //[ValidateAntiForgeryToken]特性用来防止伪造的跨站请求，配合表单中的@Html.AntiForgeryToken()使用
        //对数据进行增删改时要防止csrf攻击！
        //该特性表示检测服务器请求是否被篡改。注意：该特性只能用于post请求，get请求无效。
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
                    post.Users_id = "a000001";
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
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
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
                    post.Users_id = "a000001";
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
    }
}