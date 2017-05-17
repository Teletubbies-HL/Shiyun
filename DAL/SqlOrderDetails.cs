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
    public class SqlOrderDetails:IOrdersDetails
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<OrdersDetails> GetOrdersDetails()
        {
            var ordersds = db.OrdersDetails.ToList();
            return ordersds;
        }
        public OrdersDetails GetOrdersDetailsById(int? id)
        {
            OrdersDetails ordersd = db.OrdersDetails.Find(id);
            return ordersd;
        }
        //public IQueryable<View_OrderDetails> FindviewodById(string uid)
        //{
        //    var viewordersd = db.View_OrderDetails.Where(c => c.Users_id == uid);
        //    return viewordersd;
        //}
        public void RemoveOrdersDetails(OrdersDetails ordersd)
        {
            db.OrdersDetails.Remove(ordersd);
            db.SaveChanges();
        }
    }
}
