using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IGoodsK
    {
        IEnumerable<GoodsK> GetGoodsK();
        GoodsK GetGoodsKById(int? id);

        void AddGoodsK(GoodsK goodsk);
        void RemoveGoodsK(GoodsK goodsk);

        void EditGoodsK(GoodsK goodsk);
    }
}
