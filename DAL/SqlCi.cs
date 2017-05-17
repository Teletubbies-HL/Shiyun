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
        public IQueryable<View_CiShow> GetCiShow(int id)
        {
            var ci = db.View_CiShow.Where(c => c.Ci_id == id);
            return ci;
        }
        public IQueryable<View_CiShow> GetCiShowTops(int top)
        {
            var ci = from c in db.View_CiShow
                     orderby c.CiPai_id ascending
                     select c;
            return ci.Take(top);
        }
        public IQueryable<View_CiShow> GetCiShowTop5(int top)
        {
            var ci = from c in db.View_CiShow
                     orderby c.Ci_id ascending
                     select c;
            return ci.Take(top);
        }

        public IQueryable<Ci> whereCiById(int id)
        {
            var ci = db.Ci.Where(c => c.Ci_id == id);
            return ci;
        }
        public IQueryable<Ci> GetCibyTop(int top)
        {
            //var shi = db.Shi.OrderBy(c => c.Shi_id).Take(top);
            //return shi;
            var ci = from c in db.Ci
                      orderby c.Ci_id ascending
                      select c;
            return ci.Take(top);
        }
        public IQueryable<Ci> GetCibyLast(int last)
        {
            //var goods = db.Goods.OrderBy(c => c.Goods_id).Take(top);
            var ci = from c in db.Ci
                      orderby c.Ci_id descending
                      select c;
            return ci.Take(last);
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
