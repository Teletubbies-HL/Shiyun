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
       

        public Manager Denglu(string Managername, string ManagerPass)
        {
            var manager = db.Manager.Where(u => u.ManagerName == Managername)
                .Where(u => u.ManagerPass == ManagerPass).FirstOrDefault();
            return manager;
        }
        public Manager GetManagersById(string Managername)
        {
            Manager manager = db.Manager.Find(Managername);
            return manager;
        }
    }
}
