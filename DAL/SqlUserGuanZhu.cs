using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using System.Data.Entity;

namespace DAL
{
    public class SqlUserGuanZhu:IUserGuanzhu
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
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
    }
}
