using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace Shiyun.Controllers
{
    public class UserInfoController : Controller
    {
        ShiyunEntities db = new ShiyunEntities();
        UserInfoManager userinfomanager = new UserInfoManager();
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
                userinfomanager.AddUserInfo(userInfo);
                return RedirectToAction("Index", "Home");
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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login([Bind(Include = "Users_id,UserPass")]string Users_id,string UserPass)
        {
            try
            {
                var users = userinfomanager.Denglu(Users_id, UserPass);
                if (users != null)
                {
                    //保存到Session HttpContext.
                    Session["Users_id"] = Users_id;
                    return Content("<script>;alert('登录成功!返回首页!');window.location.href='/Home/Index'</script>");

                }
                else
                {
                    return Content("<script>;alert('该账号不存在或密码错误!');history.go(-1)</script>");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        #endregion
    }
}