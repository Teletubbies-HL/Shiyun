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
   public class CiPaiManager
    {
        ICiPai icipai = DataAccess.CreateCiPai();
        public IEnumerable<CiPai> GetCiPai()
        {
            var cipais = icipai.GetCiPai();
            return cipais;
        }
        public CiPai GetGoodsById(int? id)
        {
            CiPai cipai = icipai.GetCiPaiById(id);
            return cipai;
        }
        public IEnumerable<CiPai> whereCiPaiById(int id)
        {
            var cipai = icipai.whereCiPaiById(id);
            return cipai;
        }
        public void RemoveCiPai(CiPai cipai)
        {
            icipai.RemoveCiPai(cipai);

        }
        public void AddCiPai(CiPai cipai)
        {
            icipai.AddCiPai(cipai);

        }
        public void EditCiPai(CiPai cipai)
        {
            icipai.EditCiPai(cipai);

        }
        //获取诗词

        public IEnumerable<View_CiPaiCi> GetAllCi(int CiPaiId)
        {
            var allci = icipai.GetAllCi(CiPaiId);
            return allci;
        }

    }
}
