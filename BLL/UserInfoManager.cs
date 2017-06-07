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

        public IEnumerable<UserInfo> Jifentop(int top)
        {
            var userInfo = iuserinfo.Jifentop(top);
            return userInfo;
        }
        public IEnumerable<UserInfo> Search(string search)
        {
            var userInfo = iuserinfo.Search(search);
            return userInfo;
        }
        public IEnumerable<UserInfo> IEGetUsersById(string Users_id)
        {
            var userInfo = iuserinfo.IEGetUsersById(Users_id);
            return userInfo;
        }

        public IEnumerable<UserInfo> Jifenpaihang10()
        {
            var userInfo = iuserinfo.Jifenpaihang10();
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

        public IEnumerable<View_UserInfo> CountUserGuanzhu1ById(string uid)  //关注人数
        {
            var u1 = iuserinfo.CountUserGuanzhu1ById(uid);
            return u1;
        }
        public IEnumerable<View_UserInfo> CountUserGuanzhu2ById(string uid)  //被关注人数
        {
            var u2 = iuserinfo.CountUserGuanzhu2ById(uid);
            return u2;
        }

        public void GuanZhu(UserGuanzhu us)
        {
            iuserinfo.GuanZhu(us);
        }

        public void QuXiaoGuanZhu(string userA, string userB)
        {
            iuserinfo.QuXiaoGuanZhu(userA,userB);
        }
    }
}
