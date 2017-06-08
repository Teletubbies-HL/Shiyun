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
        IEnumerable<Ci> IEGetCiById(int id);
        IEnumerable<Ci> GetPostDetails(int postid);        
        IEnumerable<CiComment> GetCiCommentByCiId(int id);
        IQueryable<Ci> whereCiById(int id);
        IQueryable<Ci> GetCibyTop(int top);
        IQueryable<Ci> GetCibyTopZx(int top);
        IQueryable<Ci> GetCibyLast(int last);
        IEnumerable<Ci> GetbyTopandCiPaiId(int top, int cipaiid);
        void RemoveCi(Ci ci);
        void AddCi(Ci ci);
        void EditCi(Ci ci);
        IEnumerable<Ci> Search(string search);
        void RemoveRangeCiComment(IQueryable<CiComment> CiComment);
     
    }
}
