using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IUserInfo
    {
        void AddUserInfo(UserInfo userInfo);
        void AddUserAddress(UserAddress userAddress);
        UserInfo Denglu(string Users_id, string UserPass);
        UserInfo GetUsersById(string Users_id);
        void UpdateUserInfo(UserInfo userInfo);
        IEnumerable<UserInfo> IEGetUsersById(string Users_id);
        IEnumerable<UserInfo> Jifenpaihang10();
        IEnumerable<UserInfo> Search(string search);

        IEnumerable<View_UserInfo> CountUserGuanzhu1ById(string uid);
        IEnumerable<View_UserInfo> CountUserGuanzhu2ById(string uid);
        IEnumerable<UserInfo> Jifentop(int top);
        void GuanZhu(UserGuanzhu us);
        void QuXiaoGuanZhu(string userA, string userB);
    }
}
