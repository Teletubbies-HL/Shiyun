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
   public class ShiTypeManager
    {
        IShiType ishitype = DataAccess.CreateShiType();
        public IEnumerable<ShiType> GetShiType()
        {
            var shitypes = ishitype.GetShiType();
            return shitypes;
        }
        public ShiType GetGoodsById(int? id)
        {
            ShiType shitype = ishitype.GetShiTypeById(id);
            return shitype;
        }
        public IQueryable<Shi> GetShiByShiTypeId(int id)
        {
            var Shi = ishitype.GetShiByShiTypeId(id);
            return Shi;
        }

        public void RemoveShiType(ShiType goods)
        {
            ishitype.RemoveShiType(goods);

        }
        public void AddShiType(ShiType goods)
        {
            ishitype.AddShiType(goods);

        }
        public void EditShiType(ShiType goods)
        {
            ishitype.EditShiType(goods);

        }
        public void RemoveRangeShi(IQueryable<Shi> Shi)
        {
            ishitype.RemoveRangeShi(Shi);
        }
    }
}
