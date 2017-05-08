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
    public class SqlCiReply:ICiReply
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<CiReply> GetCiReply()
        {
            var cireplys = db.CiReply.ToList();
            return cireplys;
        }
        public CiReply GetCiReplyById(int? id)
        {
            CiReply cireply = db.CiReply.Find(id);
            return cireply;
        }


        public void RemoveCiReply(CiReply cireply)
        {
            db.CiReply.Remove(cireply);
            db.SaveChanges();
        }
    }
}
