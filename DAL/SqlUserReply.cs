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
    public class SqlUserReply:IUserReply
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<View_UserReply> GetUserReply(string uid) //获取留言
        {
            var psr = from us in db.View_UserReply
                      where us.U_id1 == uid
                      orderby us.ReplyTime1 ascending /*descending*/
                      select us;
            return psr;
        }
        public void AddUserReply(UserReply userreply) //添加回复
        {
            db.UserReply.Add(userreply);
            db.SaveChanges();
        }
        public void RemoveUserReplyByUser_Id(string uid)  //删除评论by user_id
        {
            var psr = from us in db.UserReply
                      where us.U_id == uid
                      select us;
            foreach (var ei in psr)
            {
                db.UserReply.Remove(ei);
            }
            db.SaveChanges();
        }
    }
}
