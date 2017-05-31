using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using System.Data.Entity;
using System.Web.Script.Serialization;
using Shiyun.Attributes;

namespace Shiyun.Controllers
{
    
    public class ChallengeController : Controller
    {
        ChallengeManager challengemanager=new ChallengeManager();
        UserInfoManager userinfomanager = new UserInfoManager();
        // GET: Challenge
        [Login]
        public ActionResult Index()
        {
            var challenge1 = challengemanager.SuijiChallengeByKid(1,3);
            var challenge4 = challengemanager.SuijiChallengeByKid(2,4);
            var challenge8 = challengemanager.SuijiChallengeByKid(3,3);
            Models.ChallengeViewModels challengevm = new Models.ChallengeViewModels();
            challengevm.Challenge1 = challenge1.Skip(0).Take(1);
            challengevm.Challenge2 = challenge1.Skip(1).Take(1);
            challengevm.Challenge3 = challenge1.Skip(2).Take(1);
            challengevm.Challenge4 = challenge4.Skip(0).Take(1);
            challengevm.Challenge5 = challenge4.Skip(1).Take(1);
            challengevm.Challenge6 = challenge4.Skip(2).Take(1);
            challengevm.Challenge7 = challenge4.Skip(3).Take(1);
            challengevm.Challenge8 = challenge8.Skip(0).Take(1);
            challengevm.Challenge9 = challenge8.Skip(1).Take(1);
            challengevm.Challenge10 = challenge8.Skip(2).Take(1);
            return View(challengevm);
        }
        [Login]
        [HttpPost]
        public string Panduan(string userdaan,int id)
        {
            var diyiti=challengemanager.GetChallengeById(id);
            var biaozhundaan = diyiti.AnswerA;
            if (userdaan == biaozhundaan)
            {
                string data = "成功";
                return data;
            }
            else
            {
                string data = "失败";
                return data;
            }
        }
        [Login]
        [HttpPost]
        public string Updatejifen(int nowjifen)
        {
            string uid= Session["Users_id"].ToString();
            var beforeuserinfo = userinfomanager.GetUsersById(uid);
            beforeuserinfo.Jifen = nowjifen + beforeuserinfo.Jifen;
            userinfomanager.UpdateUserInfo(beforeuserinfo);
            string data = "成功";
            return data;
        }
        [Login]
        [HttpPost]
        public string AddUserdati(UserDati userDati,int tid)
        {
            userDati.Users_id= Session["Users_id"].ToString();
            userDati.Timu_id = tid;
            challengemanager.AddUserdati(userDati);
            string data = "成功";
            return data;
        }
        public ActionResult ChallengePaihang()
        {
            var userinfo10 = userinfomanager.Jifenpaihang10();
            Models.ChallengeViewModels challengevm = new Models.ChallengeViewModels();
            challengevm.UserInfo10 = userinfo10;
            return View(challengevm);
        }
    }
}