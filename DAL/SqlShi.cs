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
    public class SqlShi:IShi
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Shi> GetShi()
        {
            var shi = db.Shi.ToList();
            return shi;
        }
        public Shi GetShiById(int? id)
        {
            Shi shi = db.Shi.Find(id);
            return shi;
        }
        public IEnumerable<ShiComment> GetShiCommentByShiId(int id)
        {
            var ShiComment = db.ShiComment.Include("Shi").Where(c => c.Shi_id == id);
            return ShiComment;
        }
        public IQueryable<Shi> whereShiById(int id)
        {
            var shi = db.Shi.Where(c => c.Shi_id == id);
            return shi;
        }
        public IQueryable<Shi> Search(string search)
        {
            //var shi = db.Shi.Where(c => c.ShiTitle.Contains(search)).ToList();
            //return shi;
            var shi = from po in db.Shi
                     where po.ShiTitle.Contains(search) || po.ShiContent.Contains(search)
                     select po;
            return shi;
        }
        public IQueryable<Shi> GetShibyTop(int top)
        {
            var shi = from si in db.Shi
                        orderby si.Shi_id descending
                      select si;
            return shi.Take(top);
        }
        public IQueryable<Shi> GetShibyTopZx(int top)
        {
            var shi = from si in db.Shi
                      where si.Shizhixiang =="1"
                      orderby si.Shi_id descending
                      select si;
            return shi.Take(top);
        }
        public IQueryable<Shi> GetShibyLast(int last)
        {
            //var goods = db.Goods.OrderBy(c => c.Goods_id).Take(top);
            var shi = from si in db.Shi
                        orderby si.Shi_id descending 
                        select si;
            return shi.Take(last);
        }

        public void RemoveShi(Shi shi)
        {
            //db.Shi.Add(goods);
            db.Shi.Remove(shi);
            db.SaveChanges();
        }
        public void AddShi(Shi shi)
        {
            db.Shi.Add(shi);
            db.SaveChanges();
        }
        public void EditShi(Shi shi)
        {
            db.Entry(shi).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveRangeShiComment(IQueryable<ShiComment> ShiComment)
        {
            db.ShiComment.RemoveRange(ShiComment);
        }
    }
}
