using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IOrders
    {
        IEnumerable<Orders> GetOrders();
        Orders GetOrdersById(int? id);
        void RemoveOrders(Orders orders);
        void EditOrders(Orders orders);
    }
}
