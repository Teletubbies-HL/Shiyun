using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using BLL;
using Models;
using PagedList;
using Shiyun.Attributes;
using Shiyun.Models;

namespace Shiyun.Controllers
{
    public class UserInfoController : Controller
    {
        ShiyunEntities db = new ShiyunEntities();
        UserInfoManager userinfomanager = new UserInfoManager();
        UserReplyManager userreplymanager = new UserReplyManager();
        PostManager postManager = new PostManager();
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }
        #region 注册
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register([Bind(Include = "Users_id,UserPass,UserMail")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                userInfo.Jifen = 0;
                userInfo.Pifu = "../../Images/userInfo/h_a.png";
                userInfo.Addtime = System.DateTime.Now;
                userinfomanager.AddUserInfo(userInfo);
                return Content("<script>;alert('注册成功!');window.history.go(-2); window.location.reload(); </script>");
            }
            else
            {
                return Content("<script>;alert('注册失败！');history.go(-1)</script>");
            }
        }
        public string Pipei(string id)
        {
            var num = userinfomanager.GetUsersById(id);
            if (num != null)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        #endregion
        #region 登录
        [HttpPost]
        public string Login([Bind(Include = "Users_id,UserPass")]string Users_id,string UserPass)
        {
            try
            {
                var users = userinfomanager.Denglu(Users_id, UserPass);
                if (users != null)
                {
                    //保存到Session HttpContext.
                    Session["Users_id"] = Users_id;
                    Session["UserImage"] = userinfomanager.GetUsersById(Users_id).UserImage;
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
        #region
        public ActionResult TouXiang()
        {

            return View();
        }
        #endregion
        #region 注销
        [HttpPost]
        public string Zhuxiao()
        {
            //保存到Session HttpContext.
            Session["Users_id"] = null;
            string A = "a";
            return A;
        }
        #endregion
        #region 个人中心
        public ActionResult UserCenter(string Users_id)
        {
            UserCenterViewModel uc = new UserCenterViewModel();
            uc.Uses1 = userinfomanager.IEGetUsersById(Users_id);
            ViewBag.Users_id = Users_id;
            uc.List1 = new SelectList(db.UserAddress.Where(c => c.Users_id == Users_id), "Address", "Address");//下拉列表数据绑定
            uc.UserInfo = db.UserInfo.Find(Users_id);
            Session["Guanzhu"] = 0; //未关注
            #region foreach 获取人数
            //int usera = 0;
            //var userA = userinfomanager.CountUserGuanzhu1ById(Users_id);
            //foreach (var item in userA)
            //{
            //    usera += 1;
            //}
            //uc.UserA = usera;

            //int userb = 0;
            //var userB = userinfomanager.CountUserGuanzhu2ById(Users_id);
            //foreach (var item in userB)
            //{
            //    userb += 1;
            //}
            //uc.UserB = userb;
            #endregion
            //关注人数
            uc.UserA = userinfomanager.CountUserGuanzhu1ById(Users_id).Count();
            //粉丝人数            
            uc.UserB = userinfomanager.CountUserGuanzhu2ById(Users_id).Count();
            uc.UsesAa = userinfomanager.CountUserGuanzhu1ById(Users_id);
            uc.UsesBb = userinfomanager.CountUserGuanzhu2ById(Users_id);

            //判断是否为其粉丝
            foreach (var item in userinfomanager.CountUserGuanzhu2ById(Users_id))
            {
                if (Session["Users_id"] != null)
                {
                    if (item.UserA == Session["Users_id"].ToString())
                    {
                        Session["Guanzhu"] = 1; //已经关注
                        break;
                    }
                }
                else
                {
                     break;
                }               
            }
            //原创帖
            uc.Post1 = postManager.GetPostByUser(Users_id, 1).Take(4);
            //uc.PostYuanChuang = postManager.GetPostByUser(Users_id, 1);
            //朗诵帖
            uc.Post2 = postManager.GetPostByUser(Users_id, 2).Take(4);
            //讨论帖
            uc.Post3 = postManager.GetPostByUser(Users_id, 3).Take(4);
            //草稿
            uc.Draft = postManager.GetPostDraftByUser(Users_id);
            //留言
            uc.AllUserReply = userreplymanager.GetUserReply(Users_id);
            return View(uc);
        }
        #endregion
        #region 关注
        [Login]
        public string GuanZhu(string UserB)
        {
            UserGuanzhu us = new UserGuanzhu();
            us.UserA = Session["Users_id"].ToString();
            us.UserB = UserB;
            userinfomanager.GuanZhu(us);
            string aa = userinfomanager.CountUserGuanzhu2ById(UserB).Count().ToString();
            return aa;
        }
        #endregion
        #region 取消关注
        [Login]
        public string QuXiaoGuanZhu(string UserB)
        {
            UserGuanzhu us = new UserGuanzhu();

            string UserA = Session["Users_id"].ToString();
            userinfomanager.QuXiaoGuanZhu(UserA ,UserB);
            string aa = userinfomanager.CountUserGuanzhu2ById(UserB).Count().ToString();
            return aa;
        }
        #endregion
        #region 分页数据获取
        public ActionResult _Yuanchuang(string Users_id, int? page)
        {
            ViewBag.Users_id = Users_id;        
            var yuanchaung = postManager.GetPostByUser(Users_id, 1);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(yuanchaung.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult _Langsong(string Users_id, int? page)
        {
            ViewBag.Users_id = Users_id;
            var yuanchaung = postManager.GetPostByUser(Users_id, 2);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(yuanchaung.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult _TaoLun(string Users_id, int? page)
        {
            ViewBag.Users_id = Users_id;
            var yuanchaung = postManager.GetPostByUser(Users_id, 3);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(yuanchaung.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult _Caogao(string Users_id, int? page)
        {
            ViewBag.Users_id = Users_id;
            var caogao = postManager.GetPostDraftByUser(Users_id);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(caogao.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult _GetAllUserReply(string Users_id, int? page)
        {
            ViewBag.Users_id = Users_id;
            var userreply = userreplymanager.GetUserReply(Users_id);
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(userreply.ToPagedList(pageNumber, pageSize));
        }
        #endregion
        #region  保存评论
        [HttpPost]
        [ValidateInput(false)]  //富文本编辑器使用
        [ValidateAntiForgeryToken]
        [Login]
        public string Pinglun(UserReply userReply)
        {
            if (ModelState.IsValid)
            {
                userReply.ReplyTime = System.DateTime.Now;
                userReply.Users_id = Session["Users_id"].ToString();
                userreplymanager.AddUserReply(userReply);
                return "aa";
                //Content("<script>;alert('发布成功！');window.history.go(-1);</script>");
            }
            else
            {
                return "bb";
                //Content("<script>;alert('发布失败！');history.go(-1)</script>");
            }
        }
        #endregion
        #region 修改资料
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ziliao(UserInfo userInfo) 
        {
            HttpPostedFileBase userImage = Request.Files["UserImage"];
            try
            {
                if (userImage.FileName != "")
                {
                    string filePath = userImage.FileName;
                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") +
                                      filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\Images\userInfo\") + filename;
                    string relativepath = @"/Images/userInfo/" + filename;
                    userImage.SaveAs(serverpath);
                    userInfo.UserImage = relativepath;
                }
                else
                {
                    userInfo.UserImage = db.UserInfo.Find(userInfo.Users_id).UserImage;
                }
                if (ModelState.IsValid)
                {
                    userInfo.UserImage = db.UserInfo.Find(userInfo.Users_id).UserImage;
                    userInfo.UserPass = db.UserInfo.Find(userInfo.Users_id).UserPass;
                    userInfo.Addtime = db.UserInfo.Find(userInfo.Users_id).Addtime;
                    userInfo.Jingyan = db.UserInfo.Find(userInfo.Users_id).Jingyan;
                    userInfo.Jifen = db.UserInfo.Find(userInfo.Users_id).Jifen;
                    userInfo.Pifu = db.UserInfo.Find(userInfo.Users_id).Pifu;
                    userinfomanager.UpdateUserInfo(userInfo);
                    //db.Post.Add(post);
                    //db.SaveChanges();
                    //return RedirectToAction("Index");
                    //return "aa";
                    return RedirectToAction("UserCenter","UserInfo",new { Users_id = userInfo.Users_id });
                    //return Content("<script>;alert('修改成功！');</script>");
                }
                else
                {
                    //return "bb";
                    return Content("<script>;alert('修改失败！');window.history.go(-1);window.location.reload();</script>");
                }
            }
            catch (Exception ex)
            {
                //return ex.ToString();
                return Content(ex.Message);
            }
            }

        #endregion
        #region 修改皮肤
        public string ChangePifu(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                userInfo.UserName = db.UserInfo.Find(userInfo.Users_id).UserName;
                userInfo.UserPhone = db.UserInfo.Find(userInfo.Users_id).UserPhone;
                userInfo.UserMail = db.UserInfo.Find(userInfo.Users_id).UserMail;
                userInfo.Sex = db.UserInfo.Find(userInfo.Users_id).Sex;
                userInfo.UserSign = db.UserInfo.Find(userInfo.Users_id).UserSign;
                userInfo.UserImage = db.UserInfo.Find(userInfo.Users_id).UserImage;
                userInfo.SafeQues = db.UserInfo.Find(userInfo.Users_id).SafeQues;
                userInfo.Answer = db.UserInfo.Find(userInfo.Users_id).Answer;
                userInfo.Address = db.UserInfo.Find(userInfo.Users_id).Address;
                userInfo.UserPass = db.UserInfo.Find(userInfo.Users_id).UserPass;
                userInfo.Addtime = db.UserInfo.Find(userInfo.Users_id).Addtime;
                userInfo.Jingyan = db.UserInfo.Find(userInfo.Users_id).Jingyan;
                userInfo.Jifen = db.UserInfo.Find(userInfo.Users_id).Jifen;
                userinfomanager.UpdateUserInfo(userInfo);
                //db.Post.Add(post);
                //db.SaveChanges();
                //return RedirectToAction("Index");
                return "aa";
                //return RedirectToAction("UserCenter", "UserInfo", new { Users_id = userInfo.Users_id });
                //return Content("<script>;alert('修改成功！');</script>");
            }
            else
            {
                return "bb";
            }
            
        }
        #endregion
        #region
        public ActionResult Pinglun()
            {
                return View();
            }
        #endregion
    }
}