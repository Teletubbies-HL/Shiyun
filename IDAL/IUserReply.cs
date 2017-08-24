using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IUserReply
    {
        IEnumerable<View_UserReply> GetUserReply(string uid);
        void AddUserReply(UserReply userreply);
        void RemoveUserReplyByUser_Id(string uid);
    }
}
