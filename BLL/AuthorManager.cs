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
        //public Author GetCiByAuthorId(int? id)
        //{
        //    Author author = iauthor.GetCiByAuthorId(id);
        //    return author;
        //}
        public Author GetAuthorById(int? id)
        {
            Author author = iauthor.GetAuthorById(id);
            return author;
        }
        public IQueryable<Author> whereAuthorById(int id)
        {
            var author = iauthor.whereAuthorById(id);
            return author;
        }

        public IQueryable<Ci> GetCiByAuthorId(int id)
        {
            var Ci = iauthor.GetCiByAuthorId(id);
            return Ci;
        }

        public IQueryable<Shi> GetShiByAuthorId(int id)
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
    }
}
