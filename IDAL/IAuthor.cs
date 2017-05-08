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
        Author GetAuthorById(int? id);
        IQueryable<Ci> GetCiByAuthorId(int id);
        IQueryable<Shi> GetShiByAuthorId(int id);
        void RemoveAuthor(Author author);
        void AddAuthor(Author author);
        void EditAuthor(Author author);

        void RemoveRangeCi(IQueryable<Ci> Ci);
        void RemoveRangeShi(IQueryable<Shi> Shi);
    }
}
