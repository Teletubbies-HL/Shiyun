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
      
        public Manager Denglu(string Managername, string ManagerPass)
        {
            var manager = imanager.Denglu(Managername, ManagerPass);
            return manager;
        }

        public Manager GetManagersById(string Managername)
        {
            var manager = imanager.GetManagersById(Managername);
            return manager;
        }

    }
}
