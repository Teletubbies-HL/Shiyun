using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DALFactory;

namespace BLL
{
   public class GoodsManager
    {
        IGoods igoods = DataAccess.CreateGoods();
        public IEnumerable<Goods> GetGoods()
        {
            var goodss = igoods.GetGoods();
            return goodss;
        }
        public Goods GetGoodsById(int? id)
        {
            Goods goods = igoods.GetGoodsById(id);
            return goods;
        }

       public IEnumerable<Goods> Search(string search)
       {
            var goodss = igoods.Search(search);
            return goodss;
        }
       public IEnumerable<Goods> whereGoodsBykId(string id)
       {
            var goodss = igoods.whereGoodsBykId(id);
            return goodss;
        }
       public IQueryable<Goods> whereGoodsById(int id)
       {
            var book = igoods.whereGoodsById(id);
            return book;
        }
       public IQueryable<Goods> GetGoodsbyTop(int top)
       {
            var goods = igoods.GetGoodsbyTop(top);
            return goods;
        }
       public IEnumerable<Goods> GetbyTopandGoodskId(int top, string kid)
       {
           var goods = igoods.GetbyTopandGoodskId(top, kid);
           return goods;
       }
       //public IEnumerable<Goods> GetbyTopandGoodskId()
       //{
       //    var goods = igoods.GetbyTopandGoodskId();
       //    return goods;
       //}
        public IQueryable<ShopCar> GetShopCarByGoodsId(int id)
        {
            var ShopCar = igoods.GetShopCarByGoodsId(id);
            return ShopCar;
        }
        public IQueryable<OrdersDetails> GetOrdersByGoodsId(int id)
        {
            var OrdersDetails = igoods.GetOrdersByGoodsId(id);
            return OrdersDetails;
        }
        public void RemoveGoods(Goods goods)
        {
            igoods.RemoveGoods(goods);

        }
        public void AddGoods(Goods goods)
        {
            igoods.AddGoods(goods);

        }
        public void EditGoods(Goods goods)
        {
            igoods.EditGoods(goods);

        }
        public void RemoveRangeShopCar(IQueryable<ShopCar> shopcar)
        {
            igoods.RemoveRangeShopCar(shopcar);
        }
        public void RemoveRangeOrders(IQueryable<OrdersDetails> orderdetail)
        {
            igoods.RemoveRangeOrders(orderdetail);
        }
    }
}
