using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  ITime
    {
        IEnumerable<Time> GetTime();
        Time GetTimeById(int? id);
        IQueryable<Time> GetTimebyTop(int top);
        IQueryable<Author> GetAuthorByTimeId(int id);
        IQueryable<Shi> GetShiByTimeId(int id);
        void RemoveTime(Time time);
        void AddTime(Time time);
        void EditTime(Time time);

        void RemoveRangeAuthor(IQueryable<Author> Author);
        void RemoveRangeShi(IQueryable<Shi> Shi);
    }
}
