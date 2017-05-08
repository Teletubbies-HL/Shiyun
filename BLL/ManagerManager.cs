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
    public class ManagerManager
    {
        IManager imanager = DataAccess.CreateManager();
      
        public Manager Denglu(string Manager_id, string ManagerPass)
        {
            var manager = imanager.Denglu(Manager_id, ManagerPass);
            return manager;
        }

        public Manager GetManagersById(string Manager_id)
        {
            var manager = imanager.GetManagersById(Manager_id);
            return manager;
        }
    }
}
