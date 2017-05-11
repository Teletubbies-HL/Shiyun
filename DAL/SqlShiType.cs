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
    public  class SqlShiType:IShiType
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<ShiType> GetShiType()
        {
            var shitypes = db.ShiType.ToList();
            return shitypes;
        }
        public ShiType GetShiTypeById(int? id)
        {
            ShiType shitype = db.ShiType.Find(id);
            return shitype;
        }
        public IQueryable<ShiType> GetShiTypebyTop(int top)
        {
            //var goods = db.Goods.OrderBy(c => c.Goods_id).Take(top);
            var type = from ty in db.ShiType
                       orderby ty.ShiType_id descending
                       select ty;
            return type.Take(top);
        }
        public IQueryable<Shi> GetShiByShiTypeId(int id)
        {
            var Shi = db.Shi.Include("ShiType").Where(c => c.ShiType_id == id);
            return Shi;
        }

        public void RemoveShiType(ShiType shitype)
        {
            db.ShiType.Remove(shitype);
            db.SaveChanges();
        }
        public void AddShiType(ShiType shitype)
        {
            db.ShiType.Add(shitype);
            db.SaveChanges();
        }
        public void EditShiType(ShiType shitype)
        {
            db.Entry(shitype).State = EntityState.Modified;
            db.SaveChanges();
        }


        public void RemoveRangeShi(IQueryable<Shi> Shi)
        {
            db.Shi.RemoveRange(Shi);
        }
    }
}
