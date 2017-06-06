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
   public class UserGuanzhuManager
    {
        IUserGuanzhu iu= DataAccess.CreateUserGuanzhu();
        public IEnumerable<UserGuanzhu> CountUserGuanzhu1ById(string uid)  //关注人数
        {
            var u1 = iu.CountUserGuanzhu1ById(uid);
            return u1;
        }
        public IEnumerable<UserGuanzhu> CountUserGuanzhu2ById(string uid)  //被关注人数
        {
            var u2 = iu.CountUserGuanzhu2ById(uid);
            return u2;
        }
    }
}
