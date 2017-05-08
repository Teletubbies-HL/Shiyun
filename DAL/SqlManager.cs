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
    public class SqlManager:IManager
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
       

        public Manager Denglu(string Manager_id, string ManagerPass)
        {
            var manager = db.Manager.Where(u => u.Manager_id == Manager_id)
                .Where(u => u.ManagerPass == ManagerPass).FirstOrDefault();
            return manager;
        }
        public Manager GetManagersById(string Manager_id)
        {
            Manager manager = db.Manager.Find(Manager_id);
            return manager;
        }
    }
}
