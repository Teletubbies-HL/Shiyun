using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  ILunTan
    {
        IEnumerable<LunTan> GetFenlei();
        IEnumerable<View_PostIndex> GetHostPost();
        IEnumerable<View_PostIndex> GetZhongheTaolun();
        IEnumerable<View_PostIndex> GetPaiHang();
        IEnumerable<View_PostIndex> GetYuanChuangZd(int luntanId);
        IEnumerable<LunTan> GetLuntanName(int luntanId);
        IEnumerable<View_PostIndex> GetAllPost(int luntanId);
    }
}
