using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IShiType
    {
        IEnumerable<ShiType> GetShiType();
        ShiType GetShiTypeById(int? id);
        IQueryable<Shi> GetShiByShiTypeId(int id);
        IQueryable<ShiType> GetShiTypebyTop(int top);
        void RemoveShiType(ShiType shitype);
        void AddShiType(ShiType shitype);
        void EditShiType(ShiType shitype);

        void RemoveRangeShi(IQueryable<Shi> Shi);
    }
}
