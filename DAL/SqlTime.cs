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
    public class SqlTime:ITime
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Time> GetTime()
        {
            var time = db.Time.ToList();
            return time;
        }
        public Time GetTimeById(int? id)
        {
            Time time = db.Time.Find(id);
            return time;
        }
        public IQueryable<Author> GetAuthorByTimeId(int id)
        {
            var Author = db.Author.Include("Time").Where(c => c.Time_id == id);
            return Author;
        }
        public IQueryable<Shi> GetShiByTimeId(int id)
        {
            var Shi = db.Shi.Include("Time").Where(o => o.Time_id == id);
            return Shi;
        }
        public void RemoveTime(Time time)
        {
            db.Time.Remove(time);
            db.SaveChanges();
        }
        public void AddTime(Time time)
        {
            db.Time.Add(time);
            db.SaveChanges();
        }
        public void EditTime(Time time)
        {
            db.Entry(time).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveRangeAuthor(IQueryable<Author> Author)
        {
            db.Author.RemoveRange(Author);
        }
        public void RemoveRangeShi(IQueryable<Shi> shi)
        {
            db.Shi.RemoveRange(shi);
        }
    }
}
