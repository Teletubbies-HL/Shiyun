using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IAuthor
    {
        IEnumerable<Author> GetAuthor();
        IEnumerable<View_Authorsc> GetAuthorsc(int Authorid);  
        Author GetAuthorById(int? id);
        IQueryable<Author> whereAuthorById(int id);
        IQueryable<Author> GetAuthorByTimeId(int id);
        IEnumerable<Ci> GetCiByAuthorId(int id);
        IEnumerable<Shi> GetShiByAuthorId(int id);
        void RemoveAuthor(Author author);
        void AddAuthor(Author author);
        void EditAuthor(Author author);
        IEnumerable<Author> Search(string search);
        void RemoveRangeCi(IQueryable<Ci> Ci);
        void RemoveRangeShi(IQueryable<Shi> Shi);
    }
}
