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
   public class TimeManager
    {
        ITime itime = DataAccess.CreateTime();
        public IEnumerable<Time> GetTime()
        {
            var times = itime.GetTime();
            return times;
        }

       public IEnumerable<Time> Search(string search)
       {
            var times = itime.Search(search);
            return times;
        }
        public Time GetTimeById(int? id)
        {
            Time time = itime.GetTimeById(id);
            return time;
        }
        public IQueryable<Author> GetAuthorByTimeId(int id)
        {
            var ShopCar = itime.GetAuthorByTimeId(id);
            return ShopCar;
        }
        public IQueryable<Time> GetTimebyTop(int top)
        {
            var time = itime.GetTimebyTop(top);
            return time;
        }
        public IQueryable<Shi> GetShiByTimeId(int id)
        {
            var Shi = itime.GetShiByTimeId(id);
            return Shi;
        }
        public void RemoveTime(Time time)
        {
            itime.RemoveTime(time);

        }
        public void AddTime(Time time)
        {
            itime.AddTime(time);

        }
        public void EditTime(Time time)
        {
            itime.EditTime(time);

        }
        public void RemoveRangeAuthor(IQueryable<Author> Author)
        {
            itime.RemoveRangeAuthor(Author);
        }
        public void RemoveRangeShi(IQueryable<Shi> Shi)
        {
            itime.RemoveRangeShi(Shi);
        }
        public IEnumerable<View_TimeShi> GetAllShi(int TimeId)
        {
            var allshi = itime.GetAllShi(TimeId);
            return allshi;
        }
        public IEnumerable<Time> whereTimeById(int id)
        {
            var time = itime.WhereTimeById(id);
            return time;
        }
    }
}
