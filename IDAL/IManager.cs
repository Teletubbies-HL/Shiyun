using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IManager
    {
        Manager Denglu(string Manager_id, string ManagerPass);
        Manager GetManagersById(string Manager_id);
    }
}
