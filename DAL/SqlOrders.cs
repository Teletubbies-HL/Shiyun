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
    public class SqlOrders:IOrders
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Orders> GetOrders()
        {
            var orderss = db.Orders.ToList();
            return orderss;
        }
        public Orders GetOrdersById(int? id)
        {
            Orders orders = db.Orders.Find(id);
            return orders;
        }
        public void RemoveOrders(Orders orders)
        {
            db.Orders.Remove(orders);
            db.SaveChanges();
        }
        public void EditOrders(Orders orders)
        {
            db.Entry(orders).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
