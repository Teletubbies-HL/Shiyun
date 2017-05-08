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
   public class ShiReplyManager
    {
        IShiReply ishireply = DataAccess.CreateShiReply();
        public IEnumerable<ShiReply> GetShiReply()
        {
            var shireply = ishireply.GetShiReply();
            return shireply;
        }
        public ShiReply GetShiReplyById(int? id)
        {
            ShiReply shireply = ishireply.GetShiReplyById(id);
            return shireply;
        }

        public void RemoveShiReply(ShiReply shireply)
        {
            ishireply.RemoveShiReply(shireply);

        }
    }
}
