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
        public IEnumerable<View_Authorsc> GetbyTopandCiPaiId(int top, int authorid)
        {
            //var ci = from c in db.View_Authorsc
            //         where c.Author_id == authorid
            //         //orderby c.Ci_id descending
            //         select c;
            var ci = db.View_Authorsc.Where(c => c.Author_id == authorid).OrderBy(c => c.Ci_id).Take(top);
            return ci;
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
        public IEnumerable<Author> Search(string search)
        {
            var author = db.Author.Where(c => c.AuthorName.Contains(search)).ToList();
            return author;
        }

        public IEnumerable<Author> WhereAuthorById(int id)
        {
            var author = db.Author.Where(c => c.Author_id == id);
            return author;
        }

        public IEnumerable<Ci> GetCiByAuthorId(int id)
        {
            var Ci = db.Ci.Include("Author").Where(c => c.Author_id == id);
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
        public IEnumerable<View_Authorsc> GetShiCi()
        {
            var shicis = db.View_Authorsc.ToList();
            return shicis;
        }
        //获取诗词
        public IEnumerable<View_AuthorCi> GetAllCi(int AuthorId)  //获取所有词
        {
            var AuthorCi = from ac in db.View_AuthorCi
                           where ac.Author_id == AuthorId
                           orderby ac.Ci_id descending
                           select ac;
            return AuthorCi;
        }
        public IEnumerable<View_AuthorShi> GetAllShi(int AuthorId)  //获取所有诗
        {
            var AuthorShi = from aus in db.View_AuthorShi
                            where aus.Author_id == AuthorId
                            orderby aus.Shi_id descending
                            select aus;
            return AuthorShi;
        }
    }
}
