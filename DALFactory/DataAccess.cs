using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using Models;
using IDAL;

namespace DALFactory
{
   public class DataAccess
    {
        private static string AssemblyName = ConfigurationManager.AppSettings["Path"].ToString();
        private static string db = ConfigurationManager.AppSettings["DB"].ToString();
        public static IGoods CreateGoods()
        {
            string className = AssemblyName + "." + db + "Goods";
            return (IGoods)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IUserInfo CreateUserInfo()
        {
            string className = AssemblyName + "." + db + "UserInfo";
            return (IUserInfo)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IUserReply CreateUserReply()
        {
            string className = AssemblyName + "." + db + "UserReply";
            return (IUserReply)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IShopCar CreateShopCar()
        {
            string className = AssemblyName + "." + db + "ShopCar";
            return (IShopCar)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IAuthor CreateAuthor()
        {
            string className = AssemblyName + "." + db + "Author";
            return (IAuthor)Assembly.Load(AssemblyName).CreateInstance(className);
        }       

        public static IChallenge CreateChallenge()
        {
            string className = AssemblyName + "." + db + "Challenge";
            return (IChallenge)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IChallengeK CreateChallengeK()
        {
            string className = AssemblyName + "." + db + "ChallengeK";
            return (IChallengeK)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ICi CreateCi()
        {
            string className = AssemblyName + "." + db + "Ci";
            return (ICi)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ICiComment CreateCiComment()
        {
            string className = AssemblyName + "." + db + "CiComment";
            return (ICiComment)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ICiPai CreateCiPai()
        {
            string className = AssemblyName + "." + db + "CiPai";
            return (ICiPai)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ICiReply CreateCiReply()
        {
            string className = AssemblyName + "." + db + "CiReply";
            return (ICiReply)Assembly.Load(AssemblyName).CreateInstance(className);
        }
      
        public static IGoodsK CreateGoodsK()
        {
            string className = AssemblyName + "." + db + "GoodsK";
            return (IGoodsK)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ILunTan CreateLunTan()
        {
            string className = AssemblyName + "." + db + "LunTan";
            return (ILunTan)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IManager CreateManager()
        {
            string className = AssemblyName + "." + db + "Manager";
            return (IManager)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IMessage CreateMessage()
        {
            string className = AssemblyName + "." + db + "Message";
            return (IMessage)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IOrders CreateOrders()
        {
            string className = AssemblyName + "." + db + "Orders";
            return (IOrders)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IOrdersDetails CreateOrdersDetails()
        {
            string className = AssemblyName + "." + db + "OrdersDetails";
            return (IOrdersDetails)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IPost CreatePost()
        {
            string className = AssemblyName + "." + db + "Post";
            return (IPost)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IPostReply CreatePostReply()
        {
            string className = AssemblyName + "." + db + "PostReply";
            return (IPostReply)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IShi CreateShi()
        {
            string className = AssemblyName + "." + db + "Shi";
            return (IShi)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IShiComment CreateShiComment()
        {
            string className = AssemblyName + "." + db + "ShiComment";
            return (IShiComment)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IShiReply CreateShiReply()
        {
            string className = AssemblyName + "." + db + "ShiReply";
            return (IShiReply)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IShiType CreateShiType()
        {
            string className = AssemblyName + "." + db + "ShiType";
            return (IShiType)Assembly.Load(AssemblyName).CreateInstance(className);
        }
       
        public static ITime CreateTime()
        {
            string className = AssemblyName + "." + db + "Time";
            return (ITime)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IUserDati CreateUserDati()
        {
            string className = AssemblyName + "." + db + "UserDati";
            return (IUserDati)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IUserGuanzhu CreateUserGuanzhu()
        {
            string className = AssemblyName + "." + db + "UserGuanzhu";
            return (IUserGuanzhu)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IUserInfo CreateUserInfor()
        {
            string className = AssemblyName + "." + db + "UserInfo";
            return (IUserInfo)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IVideo CreateVideo()
        {
            string className = AssemblyName + "." + db + "Video";
            return (IVideo)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IVideoComment CreateVideoComment()
        {
            string className = AssemblyName + "." + db + "VideoComment";
            return (IVideoComment)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IVideoK CreateVideoK()
        {
            string className = AssemblyName + "." + db + "VideoK";
            return (IVideoK)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IVideoReply CreateVideoReply()
        {
            string className = AssemblyName + "." + db + "VideoReply";
            return (IVideoReply)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }
}
