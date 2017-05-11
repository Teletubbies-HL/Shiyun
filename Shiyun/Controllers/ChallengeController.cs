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
        // GET: Challenge
        public ActionResult Index()
        {
            var challenge1 = challengemanager.SuijiChallengeByKid(1,3);
            var challenge4 = challengemanager.SuijiChallengeByKid(2,4);
            Models.ChallengeViewModels challengevm = new Models.ChallengeViewModels();
            challengevm.Challenge1 = challenge1.Skip(0).Take(1);
            challengevm.Challenge2 = challenge1.Skip(1).Take(1);
            challengevm.Challenge3 = challenge1.Skip(2).Take(1);
            challengevm.Challenge4 = challenge4.Skip(0).Take(1);
            challengevm.Challenge5 = challenge4.Skip(1).Take(1);
            challengevm.Challenge6 = challenge4.Skip(2).Take(1);
            challengevm.Challenge7 = challenge4.Skip(3).Take(1);
            return View(challengevm);
        }
        [HttpPost]
        public string Panduan(string userdaan,int id)
        {
            var diyiti=challengemanager.GetChallengeById(id);
            var biaozhundaan = diyiti.AnswerA;
            if (userdaan == biaozhundaan)
            {
                string data = "成功";
                //int score = 10;
                //JavaScriptSerializer jss = new JavaScriptSerializer();
                //return Json(jss.Serialize(new { Data = data, Score = score }));
                return data;
            }
            else
            {
                string data = "失败";
                //int score = 0;
                //JavaScriptSerializer jss = new JavaScriptSerializer();
                //return Json(jss.Serialize(new { Data = data, Score = score }));
                return data;
            }
        }
    }
}