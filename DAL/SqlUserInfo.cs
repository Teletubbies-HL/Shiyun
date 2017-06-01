using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Models;

namespace DAL
{
    public class SqlUserInfo:IUserInfo
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public void AddUserInfo(UserInfo userInfo)
        {
            db.UserInfo.Add(userInfo);
            db.SaveChanges();
        }
        public int CountUserInfoById(string uid)
        {
            var shopcar = db.UserInfo.Where(c => c.Users_id == uid).Select(c => c.Users_id).Count();
            return shopcar;
        }
        public void UpdateUserInfo(UserInfo userInfo)
        {
            db.Entry(userInfo).State = EntityState.Modified;
            db.SaveChanges();
        }
        public UserInfo Denglu(string Users_id, string UserPass)
        {
            var userInfo=db.UserInfo.Where(u => u.Users_id == Users_id)
                .Where(u => u.UserPass == UserPass).FirstOrDefault();
            return userInfo; 
        }
        public UserInfo GetUsersById(string Users_id)
        {
            UserInfo userInfo = db.UserInfo.Find(Users_id);
            return userInfo;
        }
        public IEnumerable<UserInfo> IEGetUsersById(string Users_id)
        {
            var userInfo = db.UserInfo.Where(c=>c.Users_id== Users_id);
            return userInfo;
        }
        public IEnumerable<UserInfo> Jifenpaihang10()
        {
            var userInfo = db.UserInfo.OrderByDescending(c=>c.Jifen).Take(10);
            return userInfo;
        }

        public IEnumerable<UserGuanzhu> CountUserGuanzhu1ById(string uid)  //关注人数
        {
            var userA = from ugz in db.UserGuanzhu
                        where ugz.UserA == uid
                        select ugz; /*db.UserGuanzhu.Where(c => c.UserA == uid).Select(c => c.UserA).Count();*/
            return userA;
        }
        public IEnumerable<UserGuanzhu> CountUserGuanzhu2ById(string uid)  //被关注人数
        {
            var userB = from ugz in db.UserGuanzhu
                        where ugz.UserB == uid
                        select ugz; /*db.UserGuanzhu.Where(c => c.UserB == uid).Select(c => c.UserB).Count();*/
            return userB;
        }
        public void GuanZhu(UserGuanzhu us)  //关注
        {
            db.UserGuanzhu.Add(us);
            db.SaveChanges();
        }
        public void QuXiaoGuanZhu(string userA, string userB)  //取消关注
        {
            var usgz = from us in db.UserGuanzhu
                       where us.UserA == userA && us.UserB == userB
                       select us;
            db.UserGuanzhu.Remove(usgz.FirstOrDefault());
            db.SaveChanges();
        }
    }
}
