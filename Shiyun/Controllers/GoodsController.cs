using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using System.Net;
using PagedList;
using System.IO;
using System.Web.Helpers;


namespace Shiyun.Controllers
{
    public class GoodsController : Controller
    {
        // GET: Goods
        ShiyunEntities db = new ShiyunEntities();
        GoodsManager goodsmanager = new GoodsManager();

        #region 商品列表
        //public ActionResult Index()
        //{
        //    var goods = goodsmanager.GetGoods();
        //    return View(goods);
        //}
        public ActionResult Index(int? page)
        {
            var goods = goodsmanager.GetGoods();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(goods.ToPagedList(pageNumber,pageSize));
        }


        #endregion

        #region 添加商品
        #region //添加商品的Get方法
        public ActionResult GoodsCreate()
        {
            //存储在ViewBag.CategoryId属性中的分类数据是为了让视图中的DropDownList辅助方法检索
            //SelectList类用于表示构建下拉列表需要的数据，构造函数的第1个参数指定了将要放在列表中的项，
            //第2个参数是一个属性名称，该属性包含当用户选择一个指定项时使用的键值，
            //第3个参数是每一项要显示的文本，第4个参数包含了最初选定项的值。
            ViewBag.GoodsK_id = new SelectList(db.GoodsK, "GoodsK_id", "GoodsKName");
            return View("GoodsCreate");

        }
        #endregion
        // POST: StoreManager/Create
        #region//添加商品的POST方法
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        //[ValidateAntiForgeryToken]特性用来防止伪造的跨站请求，配合表单中的@Html.AntiForgeryToken()使用
        //对数据进行增删改时要防止csrf攻击！
        //该特性表示检测服务器请求是否被篡改。注意：该特性只能用于post请求，get请求无效。
        //public ActionResult GoodsCreate([Bind(Include = "Goods_id,GoodsName,GoodsImage,GoodsJianjie,GoodsDetails,AddTime,Price,Count,GoodsK_id")]Goods goods)
        public ActionResult GoodsCreate([Bind(Include = "Goods_id,GoodsName,GoodsImage,GoodsJianjie,GoodsDetails,AddTime,Price,Count,GoodsK_id")]Goods goods)
        {


            try
            {
                HttpPostedFileBase postimage1 = Request.Files["GoodsImage"];

                string filePath = postimage1.FileName;
                string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                string serverpath = Server.MapPath(@"\Images\goods\") + filename;
                string relativepath = @"/Images/goods/" + filename;
                postimage1.SaveAs(serverpath);
                goods.GoodsImage = relativepath;

                goods.AddTime = System.DateTime.Now;
                goodsmanager.AddGoods(goods);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            ViewBag.GoodsK_id = new SelectList(db.GoodsK, "GoodsK_id", "GoodsKName", goods.GoodsK_id);
            return View("GoodsCreate", goods);
        }
        #endregion

        #endregion


        #region 更新商品
        #region//更新商品的Get方法
        public ActionResult GoodsEdit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = goodsmanager.GetGoodsById(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.GoodsK_id = new SelectList(db.GoodsK, "GoodsK_id", "GoodsKName", goods.GoodsK_id);
            return View(goods);
        }
        #endregion
        // POST: StoreManager/Edit/5

        #region//编辑商品的POST方法
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        //[ValidateAntiForgeryToken]特性用来防止伪造的跨站请求，配合表单中的@Html.AntiForgeryToken()使用
        //对数据进行增删改时要防止csrf攻击！
        //该特性表示检测服务器请求是否被篡改。注意：该特性只能用于post请求，get请求无效。
        public ActionResult GoodsEdit(Goods goods)
        {
            //[Bind(Include = "Goods_id,GoodsName,GoodsImage,GoodsJianjie,GoodsDetails,AddTime,Price,Count,GoodsK_id")] 
            //使用Bind属性的目的是限制用户在提交form表单时使用合适且正确的值。当我们提交一个表单时，就会检查每一个实体上绑定的特性。
            //Bind属性是一个重要的安全机制，可以防止黑客攻击。

            if (ModelState.IsValid)
            {
                HttpPostedFileBase postimage1 = Request.Files["GoodsImage"];
                if (postimage1 != null)
                {
                    string filePath = postimage1.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\Images\goods\") + filename;
                    string relativepath = @"/Images/goods/" + filename;
                    postimage1.SaveAs(serverpath);
                    goods.GoodsImage = relativepath;
                }
                db.SaveChanges();
                goodsmanager.EditGoods(goods);
                return RedirectToAction("Index");
            }
            ViewBag.GoodsK_id = new SelectList(db.GoodsK, "GoodsK_id", "GoodsKName", goods.GoodsK_id);

            return View(goods);
        }
        #endregion
        //删除给定的id的商品
        #endregion

        #region 删除商品
        public ActionResult GoodsDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goods goods = goodsmanager.GetGoodsById(id);
            if (goods == null)
            {
                return HttpNotFound();
            }
            return View(goods);
        }
        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        ////[ValidateAntiForgeryToken]特性用来防止伪造的跨站请求，配合表单中的@Html.AntiForgeryToken()使用
        ////对数据进行增删改时要防止csrf攻击！
        ////该特性表示检测服务器请求是否被篡改。注意：该特性只能用于post请求，get请求无效。
        public ActionResult DeleteConfirmed(int id)
        {
            Goods goods = goodsmanager.GetGoodsById(id);
            int goodsid = goods.Goods_id;
            var shopcar = goodsmanager.GetShopCarByGoodsId(goodsid);
            if (shopcar.Count() > 0)
            {
                goodsmanager.RemoveRangeShopCar(shopcar);
            }
            var orderdetail = goodsmanager.GetOrdersByGoodsId(goodsid);
            if (orderdetail.Count() > 0)
            {
                goodsmanager.RemoveRangeOrders(orderdetail);
            }
            goodsmanager.RemoveGoods(goods);
            return RedirectToAction("Index");
        }
        #endregion
       
    }
}