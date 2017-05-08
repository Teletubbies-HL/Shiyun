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
   public class LunTanManager
    {
        ILunTan iluntan = DataAccess.CreateLunTan();
        public IEnumerable<LunTan> GetFenlei()
        {
            var fenlei = iluntan.GetFenlei();
            return fenlei;
        }

       public IEnumerable<View_PostIndex> GetHostPost()
       {
           var hostpost = iluntan.GetHostPost();
           return hostpost;
       }
        public IEnumerable<View_PostIndex> GetZongheTaolun()
        {
            var zonghe = iluntan.GetZhongheTaolun();
            return zonghe;
        }

       public IEnumerable<View_PostIndex> GetPaiHang()
       {
            var paihang = iluntan.GetPaiHang();
            return paihang;
        }

       public IEnumerable<View_PostIndex> GetYuanChuangZd(int luntanId)
       {
            var yuanChuangZd = iluntan.GetYuanChuangZd(luntanId);
            return yuanChuangZd;
        }

       public IEnumerable<LunTan> GetLuntanName(int luntanId)
       {
            var luntanName = iluntan.GetLuntanName(luntanId);
            return luntanName;
        }
       public IEnumerable<View_PostIndex> GetAllPost(int luntanId)
       {
           var allPost = iluntan.GetAllPost(luntanId);
           return allPost;
       }
    }
}
