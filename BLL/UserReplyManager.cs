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
    public class UserReplyManager
    {
        IUserReply iuReply = DataAccess.CreateUserReply();
        public IEnumerable<View_UserReply> GetUserReply(string uid)
        {
            var psr = iuReply.GetUserReply(uid);
            return psr;
        }

        public void AddUserReply(UserReply userreply)
        {
            iuReply.AddUserReply(userreply);
        }

        public void RemoveUserReplyByUser_Id(string uid)
        {
            iuReply.RemoveUserReplyByUser_Id(uid);
        }
    }
}
