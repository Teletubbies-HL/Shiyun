using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IShiReply
    {
        IEnumerable<ShiReply> GetShiReply();
        ShiReply GetShiReplyById(int? id);


        void RemoveShiReply(ShiReply shireply);
    }
}
