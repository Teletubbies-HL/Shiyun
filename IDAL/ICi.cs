using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  ICi
    {
        IEnumerable<Ci> GetCi();
        Ci GetCiById(int? id);
        IQueryable<CiComment> GetCiCommentByCiId(int id);
        IQueryable<Ci> whereCiById(int id);
        IQueryable<Ci> GetCibyTop(int top);
        IQueryable<Ci> GetCibyLast(int last);
        void RemoveCi(Ci ci);
        void AddCi(Ci ci);
        void EditCi(Ci ci);

        void RemoveRangeCiComment(IQueryable<CiComment> CiComment);
     
    }
}
