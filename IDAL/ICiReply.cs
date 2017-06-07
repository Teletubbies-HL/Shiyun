using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  ICiReply
    {

        IEnumerable<CiReply> GetCiReply();
        CiReply GetCiReplyById(int? id);
        void AddCiReply(CiReply cireply);
        void RemoveCiReply(CiReply cipai);
    }
}
