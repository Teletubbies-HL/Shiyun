using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;
using DALFactory;

namespace BLL
{
    public class ShopCarManager
    {
        IShopCar ishopcar = DataAccess.CreateShopCar();
        public ShopCar whereShopcarById(string uid, int gid)
        {
            ShopCar shopcar = ishopcar.whereShopcarById(uid, gid);
            return shopcar;
        }

        public IQueryable<ShopCar> IQwhereShopcarById(string uid, int gid)
        {
            var shopcar = ishopcar.IQwhereShopcarById(uid, gid);
            return shopcar;
        }
        public IQueryable<ShopCar> FindShopcarById(string uid)
        {
            var shopcar = ishopcar.FindShopcarById(uid);
            return shopcar;
        }

        public IQueryable<View_ShopCar> FindviewShopcarById(string uid)
        {
            var viewshopcar = ishopcar.FindviewShopcarById(uid);
            return viewshopcar;
        }
        public int CountShopcarById(string uid, int gid)
        {
            var shopcar = ishopcar.CountShopcarById(uid, gid);
            return shopcar;
        }
        public void UpdateShopcarCount(ShopCar shopCar)
        {
            ishopcar.UpdateShopcarCount(shopCar);

        }
        public int CountShopcarCountById(string uid, int gid)
        {
            var shopcar = ishopcar.CountShopcarCountById(uid, gid);
            return shopcar;
        }
        public int beforeCount(string uid, int gid)
        {
            var shopcar = ishopcar.beforeCount(uid, gid);
            return shopcar;
        }
        public int whereCountInShopcar(string uid, int gid)
        {
            var shopcar = ishopcar.whereCountInShopcar(uid, gid);
            return shopcar;
        }
        public void RemoveRangeShopCar(IQueryable<ShopCar> shopcar)
        {
            ishopcar.RemoveRangeShopCar(shopcar);
        }

        public void AddShopCar(ShopCar shopcar)
        {
            ishopcar.AddShopCar(shopcar);
        }
    }
}
