using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Runtime.Remoting.Messaging;

namespace DAL
{
  public  class DbContextFactory
    {
        public static ShiyunEntities CreateDbContext()
        {
            ShiyunEntities dbContext = (ShiyunEntities)CallContext.GetData("dbContext");
            if (dbContext == null)
            {
                dbContext = new ShiyunEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
