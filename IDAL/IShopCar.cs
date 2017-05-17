using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IShopCar
    {
        ShopCar whereShopcarById(string uid, int gid);
        IQueryable<ShopCar> IQwhereShopcarById(string uid, int gid);
        int whereCountInShopcar(string uid, int gid);
        int CountShopcarCountById(string uid, int gid);
        int beforeCount(string uid, int gid);
        int CountShopcarById(string uid, int gid);
        void UpdateShopcarCount(ShopCar shopCar);
        IQueryable<ShopCar> FindShopcarById(string uid);
        IEnumerable<View_OrderDetails> FindviewodById(string uid);
        IQueryable<View_ShopCar> FindviewShopcarById(string uid);
        IQueryable<View_ShopCar> FindviewShopcarByIdflag1(string uid);
        void RemoveRangeShopCar(IQueryable<ShopCar> shopcar);
        void AddShopCar(ShopCar shopcar);
    }
}
