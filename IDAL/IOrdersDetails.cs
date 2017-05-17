using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IOrdersDetails
    {
        IEnumerable<OrdersDetails> GetOrdersDetails();
        OrdersDetails GetOrdersDetailsById(int? id);
        void RemoveOrdersDetails(OrdersDetails ordersdetails);
        //IQueryable<View_OrderDetails> FindviewodById(string uid);
    }
}
