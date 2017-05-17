using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Shiyun.Models
{
    public class OrderViewModels
    {
        public View_ShopCar ViewShopCar { get; set; }
        public UserInfo UserInfo { get; set; }
        public IEnumerable<View_ShopCar> ViewShopCar1 { get; set; }
        public IEnumerable<UserInfo> UserInfo1 { get; set; }
    }
}