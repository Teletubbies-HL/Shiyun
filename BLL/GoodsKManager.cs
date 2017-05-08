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
   public class GoodskManager
    {
        IGoodsK igoodsk = DataAccess.CreateGoodsK();
        public IEnumerable<GoodsK> GetGoodsK()
        {
            var booksks = igoodsk.GetGoodsK();
            return booksks;
        }
        public GoodsK GetGoodsKById(int? id)
        {
            GoodsK book = igoodsk.GetGoodsKById(id);
            return book;
        }

        public void RemoveGoodsK(GoodsK goodsk)
        {
            igoodsk.RemoveGoodsK(goodsk);

        }
        public void AddGoodsK(GoodsK goodsk)
        {
            igoodsk.AddGoodsK(goodsk);

        }
        public void EditGoodsK(GoodsK goodsk)
        {
            igoodsk.EditGoodsK(goodsk);

        }
    }
}
