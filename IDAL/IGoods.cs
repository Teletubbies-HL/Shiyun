﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IGoods
    {
        IEnumerable<Goods> GetGoods();
        Goods GetGoodsById(int? id);
        IQueryable<Goods> whereGoodsById(int id);
        IQueryable<Goods> GetGoodsbyTop(int top);
        IEnumerable<Goods> GetbyTopandGoodskId(int top, string kid);
        //IEnumerable<Goods> GetbyTopandGoodskId();
        IQueryable<ShopCar> GetShopCarByGoodsId(int id);
        IQueryable<OrdersDetails> GetOrdersByGoodsId(int id);
        void RemoveGoods(Goods goods);
        void AddGoods(Goods goods);
        void EditGoods(Goods goods);

        void RemoveRangeShopCar(IQueryable<ShopCar> shopcar);
        void RemoveRangeOrders(IQueryable<OrdersDetails> orderdetail);
    
}
}
