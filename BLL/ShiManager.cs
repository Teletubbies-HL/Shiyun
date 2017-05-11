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
   public class ShiManager
    {
        IShi ishi = DataAccess.CreateShi();
        public IEnumerable<Shi> GetShi()
        {
            var shis = ishi.GetShi();
            return shis;
        }
        public Shi GetShiById(int? id)
        {
            Shi shi = ishi.GetShiById(id);
            return shi;
        }
        public IQueryable<ShiComment> GetShiCommentByShiId(int id)
        {
            var ShiComment = ishi.GetShiCommentByShiId(id);
            return ShiComment;
        }
        public IQueryable<Shi> whereShiById(int id)
        {
            var shi = ishi.whereShiById(id);
            return shi;
        }

        public IQueryable<Shi> GetShibyTop(int top)
        {
            var shi = ishi.GetShibyTop(top);
            return shi;
        }
        public IQueryable<Shi> GetShibyLast(int last)
        {
            var shi = ishi.GetShibyLast(last);
            return shi;
        }
        public void RemoveShi(Shi shi)
        {
            ishi.RemoveShi(shi);

        }
        public void AddShi(Shi shi)
        {
            ishi.AddShi(shi);

        }
        public void EditShi(Shi shi)
        {
            ishi.EditShi(shi);

        }
        public void RemoveRangeShiComment(IQueryable<ShiComment> ShiComment)
        {
            ishi.RemoveRangeShiComment(ShiComment);
        }
    }
}
