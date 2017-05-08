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
   public class CiReplyManager
    {
        ICiReply icireply = DataAccess.CreateCiReply();
        public IEnumerable<CiReply> GetCiReply()
        {
            var cireplys = icireply.GetCiReply();
            return cireplys;
        }
        public CiReply GetCisById(int? id)
        {
            CiReply cireply = icireply.GetCiReplyById(id);
            return cireply;
        }


        public void RemoveCiReply(CiReply cireply)
        {
            icireply.RemoveCiReply(cireply);

        }
    }
}
