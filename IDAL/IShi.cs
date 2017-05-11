using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IShi
    {
        IEnumerable<Shi> GetShi();
        Shi GetShiById(int? id);
        IQueryable<ShiComment> GetShiCommentByShiId(int id);
        
        IQueryable<Shi> whereShiById(int id);
        IQueryable<Shi> GetShibyTop(int top);
        IQueryable<Shi> GetShibyLast(int last);
        //IEnumerable<Shi> GetbyTopandShikId(int top, string kid);
        void RemoveShi(Shi shi);
        void AddShi(Shi shi);
        void EditShi(Shi shi);

        void RemoveRangeShiComment(IQueryable<ShiComment> ShiComment);
    }
}
