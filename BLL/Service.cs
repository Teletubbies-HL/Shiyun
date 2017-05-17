using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BLL
{
    //class Service
    //{
    //}
    public static class Service
    {
        public static List<Time> GetTime()
        {
            List<Time> result = new List<Time>();

            result.Add(new Time() { Time_id = 1, TimeName = "山东省" });
            result.Add(new Time() { Time_id = 2, TimeName = "江苏省" });
            return result;
        }

        public static List<Author> GetAuthorByTime(int timeId)
        {
            List<Author> result = new List<Author>();
            result.Add(new Author() { Author_id = 1, AuthorName = "济南市", Time_id = 1 });
            result.Add(new Author() { Author_id = 2, AuthorName = "青岛市", Time_id = 1 });
            result.Add(new Author() { Author_id = 3, AuthorName = "南京市", Time_id = 2 });
            result.Add(new Author() { Author_id = 4, AuthorName = "苏州市", Time_id = 2 });

            return result.Where(r => r.Time_id == timeId).ToList();
        }
    }
}
