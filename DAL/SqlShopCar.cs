using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlShopCar:IShopCar
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        
        public ShopCar whereShopcarById(string uid,int gid)
        {
            ShopCar shopcar = db.ShopCar.Where(c => c.Users_id == uid)
                .Where(c => c.Goods_id== gid).FirstOrDefault();
            return shopcar;
        }
        public IQueryable<ShopCar> IQwhereShopcarById(string uid, int gid)
        {
            var shopcar = db.ShopCar.Where(c => c.Users_id == uid).Where(c => c.Goods_id == gid);
            return shopcar;
        }
        public IQueryable<ShopCar> FindShopcarById(string uid)
        {
            var shopcar = db.ShopCar.Where(c => c.Users_id == uid);
            return shopcar;
        }
        public IEnumerable<View_OrderDetails> FindviewodById(string uid)
        {
            var viewordersd = db.View_OrderDetails.Where(c => c.Users_id == uid).ToList();
            return viewordersd;
        }
        public IQueryable<View_ShopCar> FindviewShopcarById(string uid)
        {
            var viewshopcar = db.View_ShopCar.Where(c => c.Users_id == uid);
            return viewshopcar;
        }
        public IQueryable<View_ShopCar> FindviewShopcarByIdflag1(string uid)
        {
            var viewshopcar = db.View_ShopCar.Where(c => c.Users_id == uid).Where(c=>c.flag==1);
            return viewshopcar;
        }
        public int CountShopcarById(string uid, int gid)
        {
            var shopcar = db.ShopCar.Where(c => c.Users_id == uid)
                .Where(c => c.Goods_id == gid).Select(c => c.ShopCar_id).Count();
            return shopcar;
        }
        public void UpdateShopcarCount(ShopCar shopCar)
        {
            db.Entry(shopCar).State = EntityState.Modified;
            db.SaveChanges();
        }
        public int CountShopcarCountById(string uid, int gid)
        {
            var shopcar = db.ShopCar.Where(c => c.Users_id == uid)
                .Where(c => c.Goods_id == gid).Select(c => c.Count).Count(); ;
            return shopcar;
        }
        public int beforeCount(string uid, int gid)
        {
            var shopcar = db.ShopCar.Where(c => c.Users_id == uid)
                .Where(c => c.Goods_id == gid).Select(c => c.Count).FirstOrDefault(); ;
            return shopcar;
        }
        public int whereCountInShopcar(string uid, int gid)
        {
            var shopcar = db.ShopCar.Where(c => c.Users_id == uid)
                .Where(c => c.Goods_id == gid).Select(c=>c.Count).FirstOrDefault();
            //(from g in db.ShopCar
            // where g.Goods_id == shopCar.Goods_id
            // where g.Users_id == shopCar.Users_id
            // select g.Count).FirstOrDefault();
            return shopcar;
        }
        public void RemoveRangeShopCar(IQueryable<ShopCar> shopcar)
        {
            db.ShopCar.RemoveRange(shopcar);
            db.SaveChanges();
        }
        public void AddShopCar(ShopCar shopcar)
        {
            db.ShopCar.Add(shopcar);
            db.SaveChanges();
        }
    }
}
