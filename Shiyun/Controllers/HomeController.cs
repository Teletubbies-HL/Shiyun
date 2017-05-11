using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shiyun.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #region ckeditor编辑器图片上传
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            //获取图片文件名
            var fileName = System.IO.Path.GetFileName(upload.FileName);
            var filePhysicalPath = Server.MapPath("~/Images/upload/" + fileName);//我把它保存在网站根目录的 upload 文件夹，需要在项目中添加对应的文件夹        
            upload.SaveAs(filePhysicalPath);  //上传图片到指定文件夹
            var url = "/Images/upload/" + fileName;
            var CKEditorFuncNum = System.Web.HttpContext.Current.Request["CKEditorFuncNum"];
            //上传成功后，我们还需要通过以下的一个脚本把图片返回到第一个tab选项
            return Content("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\");</script>");     
        }
        #endregion
    }
}