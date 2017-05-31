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
        public ShiType GetShiTypeById(int? id)
        {
            ShiType shitype = ishitype.GetShiTypeById(id);
            return shitype;
        }
        public IEnumerable<ShiType> whereShiTypeById(int id)
        {
            var shitype = ishitype.WhereShiTypeById(id);
            return shitype;
        }
        public IEnumerable<Shi> GetShiByShiTypeId(int id)
        {
            var Shi = ishitype.GetShiByShiTypeId(id);
            return Shi;
        }
        public IQueryable<ShiType> GetShiTypebyTop(int top)
        {
            var shitype = ishitype.GetShiTypebyTop(top);
            return shitype;
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
        //获取诗

        public IEnumerable<View_ShitypeA> GetAllShi(int ShiTypeId)
        {
            var allshi = ishitype.GetAllShi(ShiTypeId);
            return allshi;
        }

    }
}
