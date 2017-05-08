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
        public IQueryable<CiComment> GetCiCommentByCiId(int id)
        {
            var CiComment = ici.GetCiCommentByCiId(id);
            return CiComment;
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
