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
   public class OrdersDetailsManager
    {
        IOrdersDetails iordersd = DataAccess.CreateOrdersDetails();
        public IEnumerable<OrdersDetails> GetOrdersDetails()
        {
            var ordersds = iordersd.GetOrdersDetails();
            return ordersds;
        }

       //public IQueryable<View_OrderDetails> FindviewodById(string uid)
       //{
       //     var viewordersd = iordersd.FindviewodById(uid);
       //     return viewordersd;
       // }
        public OrdersDetails GetOrdersDetailsById(int? id)
        {
            OrdersDetails ordersd = iordersd.GetOrdersDetailsById(id);
            return ordersd;
        }

        public void RemoveOrdersDetails(OrdersDetails ordersd)
        {
            iordersd.RemoveOrdersDetails(ordersd);

        }
    }
}
