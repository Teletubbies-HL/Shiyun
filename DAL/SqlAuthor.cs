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
  public  class SqlAuthor:IAuthor
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Author> GetAuthor()
        {
            var author = db.Author.ToList();
            return author;
        }
      
        public Author GetAuthorById(int? id)
        {
            Author author = db.Author.Find(id);
            return author;
        }
        public IQueryable<Author> GetAuthorByTimeId(int id)
        {
            var Author = db.Author.Include("Time").Where(c => c.Time_id == id);
            return Author;
        }
        public IQueryable<Author> whereAuthorById(int id)
        {
            var author = db.Author.Where(c => c.Author_id == id);
            return author;
        }
        //public IEnumerable<View_Authorsc> whereShiByAId(int id)
        //{
        //    var author = db.Author.Where(c => c.Author_id == id);
        //    return author;
        //}

        public IEnumerable<Ci> GetCiByAuthorId(int id)
        {
            var Ci = db.Ci.Include("Author").Where(c => c.Author_id == id).ToList();
            return Ci;
        }
        public IEnumerable<Shi> GetShiByAuthorId(int id)
        {
            var Shi = db.Shi.Include("Author").Where(o => o.Author_id == id).ToList();
            return Shi;
        }
        public void RemoveAuthor(Author author)
        {
            db.Author.Remove(author);
            db.SaveChanges();
        }
        public void AddAuthor(Author author)
        {
            db.Author.Add(author);
            db.SaveChanges();
        }
        public void EditAuthor(Author author)
        {
            db.Entry(author).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveRangeCi(IQueryable<Ci> Ci)
        {
            db.Ci.RemoveRange(Ci);
        }
        public void RemoveRangeShi(IQueryable<Shi> Shi)
        {
            db.Shi.RemoveRange(Shi);
        }

        public IEnumerable<View_Authorsc> GetAuthorsc(int Authorid)
        {
            var auscid = from au in db.View_Authorsc
                         where au.Author_id== Authorid
                         select au;
            return auscid;
            //var authorsc = db.View_Authorsc.ToList();
            //return authorsc;
        }
    }
}
