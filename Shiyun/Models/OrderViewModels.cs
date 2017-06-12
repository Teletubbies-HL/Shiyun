using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Shiyun.Models
{
    public class OrderViewModels
    {
        public View_ShopCar ViewShopCar { get; set; }
        public UserInfo UserInfo { get; set; }
        public IEnumerable<View_ShopCar> ViewShopCar1 { get; set; }
        public IEnumerable<UserInfo> UserInfo1 { get; set; }
        public Orders Orders { get; set; }
        public OrdersDetails OrdersDetails { get; set; }
        public UserAddress UserAddress { get; set; }
        public IEnumerable<SelectListItem> List1 { get; set; }
        public IEnumerable<Orders> Orders1 { get; set; }
        public IEnumerable<OrdersDetails> OrdersDetails1{ get; set; }
    }
}