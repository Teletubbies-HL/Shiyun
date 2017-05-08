using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Shiyun.Models
{
    public class ShopCarViewModel
    {
        public View_ShopCar ViewShopCar { get; set; }
        public Goods goods { get; set; }
        public ShopCar shopcars { get; set; }
        public IEnumerable<Goods> Goods1 { get; set; }
        public IEnumerable<ShopCar> ShopCar1 { get; set; }
        public IEnumerable<View_ShopCar> ViewShopCar1 { get; set; }
    }
}