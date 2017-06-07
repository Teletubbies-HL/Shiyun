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
   public class CiManager
    {
        ICi ici = DataAccess.CreateCi();
        public IEnumerable<Ci> GetCi()
        {
            var cis = ici.GetCi();
            return cis;
        }
        public Ci GetCisById(int? id)
        {
            Ci ci = ici.GetCiById(id);
            return ci;
        }
        public IEnumerable<Ci> GetPostDetails(int postid)
        {
            var pstd = ici.GetPostDetails(postid);
            return pstd;
        }
        public IEnumerable<CiComment> GetCiCommentByCiId(int id)
        {
            var CiComment = ici.GetCiCommentByCiId(id);
            return CiComment;
        }
        public IQueryable<Ci> whereCiById(int id)
        {
            var ci = ici.whereCiById(id);
            return ci;
        }

       public IEnumerable<Ci> Search(string search)
       {
            var ci = ici.Search(search);
            return ci;
        }
        public IQueryable<Ci> GetCibyTop(int top)
        {
            var ci = ici.GetCibyTop(top);
            return ci;
        }
        public IQueryable<Ci> GetCibyTopZx(int top)
        {
            var ci = ici.GetCibyTopZx(top);
            return ci;
        }
        public IQueryable<Ci> GetCibyLast(int last)
        {
            var ci = ici.GetCibyLast(last);
            return ci;
        }
        public IEnumerable<Ci> GetbyTopandCiPaiId(int top, int cipaiid)
        {
            var ci = ici.GetbyTopandCiPaiId(top, cipaiid);
            return ci;
        }
        public void RemoveCi(Ci ci)
        {
            ici.RemoveCi(ci);

        }
        public void AddCi(Ci ci)
        {
            ici.AddCi(ci);

        }
        public void EditCi(Ci ci)
        {
            ici.EditCi(ci);

        }
        public void RemoveRangeCiComment(IQueryable<CiComment> CiComment)
        {
            ici.RemoveRangeCiComment(CiComment);
        }
       
    }
}
