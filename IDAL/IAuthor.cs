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
        //IEnumerable<View_Authorsc> GetAuthorsc(int Authorid);
        IEnumerable<View_Authorsc> GetShiCi();
        IEnumerable<View_Authorsc> GetbyTopandCiPaiId(int top, int authorid);
        Author GetAuthorById(int? id);
        IEnumerable<Author> WhereAuthorById(int id);
        IQueryable<Author> GetAuthorByTimeId(int id);
        IEnumerable<Ci> GetCiByAuthorId(int id);
        IEnumerable<Shi> GetShiByAuthorId(int id);
        void RemoveAuthor(Author author);
        void AddAuthor(Author author);
        void EditAuthor(Author author);

        void RemoveRangeCi(IQueryable<Ci> Ci);
        void RemoveRangeShi(IQueryable<Shi> Shi);
        //获取诗词
        IEnumerable<View_AuthorCi> GetAllCi(int AuthorId);
        IEnumerable<View_AuthorShi> GetAllShi(int AuthorId);
    }
}
