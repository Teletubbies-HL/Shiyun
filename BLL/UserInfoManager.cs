using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using Models;

namespace BLL
{
    public class UserInfoManager
    {
        IUserInfo iuserinfo = DataAccess.CreateUserInfo();
        public void AddUserInfo(UserInfo userInfo)
        {
            iuserinfo.AddUserInfo(userInfo);
        }

        public IEnumerable<UserInfo> IEGetUsersById(string Users_id)
        {
            var userInfo = iuserinfo.IEGetUsersById(Users_id);
            return userInfo;
        }
        public void UpdateUserInfo(UserInfo userInfo)
        {
            iuserinfo.UpdateUserInfo(userInfo);
        }
        public UserInfo Denglu(string Users_id, string UserPass)
        {
            var userInfo = iuserinfo.Denglu(Users_id, UserPass);
            return userInfo;
        }

        public UserInfo GetUsersById(string Users_id)
        {
            var userInfo = iuserinfo.GetUsersById(Users_id);
            return userInfo;
        }
    }
}
