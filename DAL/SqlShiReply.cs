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
    public class SqlShiReply:IShiReply
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<ShiReply> GetShiReply()
        {
            var shireply = db.ShiReply.ToList();
            return shireply;
        }
        public ShiReply GetShiReplyById(int? id)
        {
            ShiReply shireply = db.ShiReply.Find(id);
            return shireply;
        }

        public void AddShiReply(ShiReply shiireply)
        {
            db.ShiReply.Add(shiireply);
            db.SaveChanges();
        }
        public void RemoveShiReply(ShiReply shireply)
        {
            //db.Shi.Add(goods);
            db.ShiReply.Remove(shireply);
            db.SaveChanges();
        }

    }
}
