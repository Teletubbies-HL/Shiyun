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
    public class SqlCi:ICi
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Ci> GetCi()
        {
            var cis = db.Ci.ToList();
            return cis;
        }
        public Ci GetCiById(int? id)
        {
            Ci ci = db.Ci.Find(id);
            return ci;
        }
        public IQueryable<CiComment> GetCiCommentByCiId(int id)
        {
            var CiComment = db.CiComment.Include("Ci").Where(c => c.Ci_id == id);
            return CiComment;
        }
       
        public void RemoveCi(Ci ci)
        {
            db.Ci.Remove(ci);
            db.SaveChanges();
        }
        public void AddCi(Ci ci)
        {
            db.Ci.Add(ci);
            db.SaveChanges();
        }
        public void EditCi(Ci ci)
        {
            db.Entry(ci).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveRangeCiComment(IQueryable<CiComment> CiComment)
        {
            db.CiComment.RemoveRange(CiComment);
        }
      
    }
}
