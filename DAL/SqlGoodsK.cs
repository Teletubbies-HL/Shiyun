using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using System.Data.Entity;

namespace DAL
{
    public class SqlGoodsK:IGoodsK
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<GoodsK> GetGoodsK()
        {
            var goodsks = db.GoodsK.ToList();
            return goodsks;
        }
        public GoodsK GetGoodsKById(int? id)
        {
            GoodsK goodsk = db.GoodsK.Find(id);
            return goodsk;
        }

        public void RemoveGoodsK(GoodsK goodsk)
        {
            db.GoodsK.Remove(goodsk);
            db.SaveChanges();
        }
        public void AddGoodsK(GoodsK goodsk)
        {
            db.GoodsK.Add(goodsk);
            db.SaveChanges();
        }
        public void EditGoodsK(GoodsK goodsk)
        {
            db.Entry(goodsk).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
