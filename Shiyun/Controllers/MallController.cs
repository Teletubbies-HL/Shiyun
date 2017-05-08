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
    public class MallController : Controller
    {
        // GET: Mall
        ShiyunEntities db = new ShiyunEntities();
        GoodsManager goodsmanager = new GoodsManager();
        ShopCarManager shopcarmanager = new ShopCarManager();
        #region 商城主页
        public ActionResult Index()
        {
            var goodses1 = goodsmanager.whereGoodsById(1);
            var goodses2 = goodsmanager.whereGoodsById(43);
            var goodses3 = goodsmanager.whereGoodsById(3);
            var goodses4 = goodsmanager.whereGoodsById(2);
            var goodses5 = goodsmanager.whereGoodsById(10);
            var goodses6 = goodsmanager.whereGoodsById(5);
            var goodses7 = goodsmanager.whereGoodsById(8);
            var goodstop10 = goodsmanager.GetGoodsbyTop(10);
            var goodskind1top9 = goodsmanager.GetbyTopandGoodskId(9, "1")/*goodsmanager.GetbyTopandGoodskId(9, "1")*/;
            var goodskind2top9 = goodsmanager.GetbyTopandGoodskId(9, "2");
            var goodskind3top9 = goodsmanager.GetbyTopandGoodskId(9, "3");
            var goodskind4top9 = goodsmanager.GetbyTopandGoodskId(9, "4");
            var goodskind5top9 = goodsmanager.GetbyTopandGoodskId(9, "5");
            Models.MallViewModels mallvm = new Models.MallViewModels();
            mallvm.Goodses1 = goodses1;
            mallvm.Goodses2 = goodses2;
            mallvm.Goodses3 = goodses3;
            mallvm.Goodses4 = goodses4;
            mallvm.Goodses5 = goodses5;
            mallvm.Goodses6 = goodses6;
            mallvm.Goodses7 = goodses7;
            mallvm.Goodstop10 = goodstop10;
            mallvm.Goodskind1top9 = goodskind1top9;
            mallvm.Goodskind2top9 = goodskind2top9;
            mallvm.Goodskind3top9 = goodskind3top9;
            mallvm.Goodskind4top9 = goodskind4top9;
            mallvm.Goodskind5top9 = goodskind5top9;
            return View(mallvm);
        }
        #endregion

        #region 商品详情页
        public ActionResult GoodsDetail(int id)
        {
            Session["Goods_id"] = id;
            if (Session["Goods_id"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var goodses = goodsmanager.GetGoodsById(id);
            if (goodses == null)
            {
                return HttpNotFound();
            }
            return View(goodses);
        }
        #endregion

        #region 加入购物车
        [Login]
        [HttpPost]
        public ActionResult jrgwc([Bind(Include = "Goods_id,Count,Price,Users_id,note,Time,flag")] ShopCar shopCar)
        {
            //if (Session["Users_id"] != null)
            //{
            string name = Request.Form["ljgm"];
            shopCar.Users_id = Session["Users_id"].ToString();
            var nowcount = shopCar.Count;
            var nowgoodsid = shopCar.Goods_id;
            var a = shopcarmanager.CountShopcarById(shopCar.Users_id, shopCar.Goods_id);
            //db.ShopCar.Where(c => c.Users_id == shopCar.Users_id)
            //.Where(c => c.Goods_id == shopCar.Goods_id).Select(c => c.ShopCar_id)
            //.Count();
            var b = shopcarmanager.CountShopcarCountById(shopCar.Users_id, shopCar.Goods_id);
            //db.ShopCar.Where(c => c.Users_id == shopCar.Users_id)
            //    .Where(c => c.Goods_id == shopCar.Goods_id)
            //    .Select(c => c.Count)
            //    .Count();
            var beforecount = shopcarmanager.beforeCount(shopCar.Users_id, shopCar.Goods_id);
            //(from g in db.ShopCar
            //               where g.Goods_id == shopCar.Goods_id
            //               where g.Users_id == shopCar.Users_id
            //               select g.Count).FirstOrDefault();
            if (a == 1)
            {
                //先查询出拿一条数据，再赋值
                var beforeshopcar = shopcarmanager.whereShopcarById(shopCar.Users_id, nowgoodsid);
                beforeshopcar.Goods_id = nowgoodsid;
                beforeshopcar.Users_id = Session["Users_id"].ToString();
                beforeshopcar.Count = nowcount + beforecount;
                beforeshopcar.note = "";
                beforeshopcar.Time = System.DateTime.Now;
                beforeshopcar.flag = 0;
                shopcarmanager.UpdateShopcarCount(beforeshopcar);
                if (name == "1")
                {
                    return RedirectToAction("Shopcar", "Mall");
                }
                else {
                    if (b == 1)
                    {
                        return Content("<script>;alert('添加成功！');history.go(-1)</script>");
                    }
                    else
                    {
                        return Content("<script>;alert('添加失败！');history.go(-1)</script>");
                    }
                }
            }
            else
            {
                shopCar.Users_id = Session["Users_id"].ToString();
                shopCar.note = "";
                shopCar.Time = System.DateTime.Now;
                shopCar.flag = 0;
                //db.ShopCar.Add(shopCar);
                //db.SaveChanges();
                shopcarmanager.AddShopCar(shopCar);
                if (name == "1")
                {
                    return RedirectToAction("Shopcar", "Mall");
                }
                else
                {
                    var c = shopcarmanager.CountShopcarById(shopCar.Users_id, shopCar.Goods_id);
                    if (c == 1)
                    {
                        return Content("<script>;alert('加入购物车成功！');history.go(-1)</script>");
                    }
                    else
                    {
                        return Content("<script>;alert('加入购物车失败！');history.go(-1)</script>");
                    }
                }
            }
            //}
            //else
            //{
            //    return Content("<script>;alert('还未登录！请登录');history.go(-1)</script>");
            //}
        }
        #endregion

        #region 购物车页
        [Login]
        public ActionResult Shopcar()
        {
            //if (Session["Users_id"] != null)
            //{
            string uid = Session["Users_id"].ToString();
            var vsc = shopcarmanager.FindviewShopcarById(uid);
            return View(vsc);
            //}
            //else
            //{
            //    return RedirectToAction("Login", "UserInfo");
            //}
        }
        #endregion

        #region 购物车更新数量
        [HttpPost]
        public string Update(int id, int count)
        {
            string uid = Session["Users_id"].ToString();
            var beforeshopcar = shopcarmanager.whereShopcarById(uid, id);
            beforeshopcar.Goods_id = id;
            beforeshopcar.Users_id = Session["Users_id"].ToString();
            beforeshopcar.Count = count;
            beforeshopcar.note = "";
            beforeshopcar.Time = System.DateTime.Now;
            beforeshopcar.flag = 0;
            shopcarmanager.UpdateShopcarCount(beforeshopcar);
            if (shopcarmanager.CountShopcarById(uid, id) != 0)
            {
                string data = "修改成功";
                return data;
            }
            else
            {
                string data = "修改失败";
                return data;
            }
        }
        #endregion

        #region 购物车删除
        public ActionResult Delete(int id)
        {
            string uid = Session["Users_id"].ToString();
            var existShopCar = shopcarmanager.IQwhereShopcarById(uid, id);
            if (existShopCar != null)
            {
                var newshopcar = shopcarmanager.FindShopcarById(uid);
                shopcarmanager.RemoveRangeShopCar(existShopCar);
                return Content("<script>;alert('删除成功！');window.location.href='/Mall/ShopCar'</script>");
            }
            return RedirectToAction("Shopcar");
        }

        #endregion
    }
}