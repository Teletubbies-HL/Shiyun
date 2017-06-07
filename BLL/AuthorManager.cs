using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DALFactory;

namespace BLL
{
   public class AuthorManager
    {
        IAuthor iauthor = DataAccess.CreateAuthor();
        public IEnumerable<Author> GetAuthor()
        {
            var authors = iauthor.GetAuthor();
            return authors;
        }
        //public IEnumerable<View_Authorsc> GetAuthorsc(int Authorid)
        //{
        //    var authorsc = iauthor.GetAuthorsc(Authorid);
        //    return authorsc;
        //}
        public IEnumerable<View_Authorsc> GetbyTopandCiPaiId(int top, int authorid)
        {
            var ci = iauthor.GetbyTopandCiPaiId(top, authorid);
            return ci;
        }
        public IEnumerable<Author> Search(string search)
        {
            var authors = iauthor.Search(search);
            return authors;
        }
        public Author GetAuthorById(int? id)
        {
            Author author = iauthor.GetAuthorById(id);
            return author;
        }
        public IEnumerable<Author> whereAuthorById(int id)
        {
            var author = iauthor.WhereAuthorById(id);
            return author;
        }
        public IQueryable<Author> GetAuthorByTimeId(int id)
        {
            var author = iauthor.GetAuthorByTimeId(id);
            return author;
        }

        public IEnumerable<Ci> GetCiByAuthorId(int id)
        {
            var Ci = iauthor.GetCiByAuthorId(id);
            return Ci;
        }

        public IEnumerable<Shi> GetShiByAuthorId(int id)
        {
            var Shi = iauthor.GetShiByAuthorId(id);
            return Shi;
        }
        public void RemoveAuthor(Author author)
        {
            iauthor.RemoveAuthor(author);

        }
        public void AddAuthor(Author author)
        {
            iauthor.AddAuthor(author);

        }
        public void EditAuthor(Author author)
        {
            iauthor.EditAuthor(author);

        }
        public void RemoveRangeCi(IQueryable<Ci> Ci)
        {
            iauthor.RemoveRangeCi(Ci);
        }
        public void RemoveRangeShi(IQueryable<Shi> Shi)
        {
            iauthor.RemoveRangeShi(Shi);
        }
        public IEnumerable<View_Authorsc> GetShiCi()
        {
            var shicis = iauthor.GetShiCi();
            return shicis;
        }
        //获取诗词

        public IEnumerable<View_AuthorShi> GetAllShi(int AuthorId)
        {
            var allshi = iauthor.GetAllShi(AuthorId);
            return allshi;
        }
        public IEnumerable<View_AuthorCi> GetAllCi(int AuthorId)
        {
            var allci = iauthor.GetAllCi(AuthorId);
            return allci;
        }
    }
}
