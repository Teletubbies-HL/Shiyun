using System;
using System.Collections.Generic;
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
    }
}
