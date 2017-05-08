using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using System.Data.Entity;
using Shiyun.Attributes;

namespace Shiyun.Controllers
{
    public class ChallengeController : Controller
    {
        ChallengeManager challengemanager=new ChallengeManager();
        // GET: Challenge
        public ActionResult Index()
        {
            var challenge1 = challengemanager.SuijiChallengeByKid(1);
            var challenge2 = challengemanager.SuijiChallengeByKid(1);
            var challenge3 = challengemanager.SuijiChallengeByKid(1);
            Models.ChallengeViewModels challengevm = new Models.ChallengeViewModels();
            challengevm.Challenge1 = challenge1;
            challengevm.Challenge2 = challenge2;
            challengevm.Challenge3 = challenge3;
            return View(challengevm);
        }
    }
}