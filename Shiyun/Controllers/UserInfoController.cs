using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
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
                userInfo.Jifen = 0;
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
    }
}