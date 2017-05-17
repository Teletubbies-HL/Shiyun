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
    public class SqlCiPai:ICiPai
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<CiPai> GetCiPai()
        {
            var cipais = db.CiPai.ToList();
            return cipais;
        }
        public CiPai GetCiPaiById(int? id)
        {
            CiPai cipai = db.CiPai.Find(id);
            return cipai;
        }
        public IQueryable<CiPai> whereCiPaiById(int id)
        {
            var cipai = db.CiPai.Where(c => c.CiPai_id == id);
            return cipai;
        }

        public void RemoveCiPai(CiPai cipai)
        {
            db.CiPai.Remove(cipai);
            db.SaveChanges();
        }
        public void AddCiPai(CiPai cipai)
        {
            db.CiPai.Add(cipai);
            db.SaveChanges();
        }
        public void EditCiPai(CiPai cipai)
        {
            db.Entry(cipai).State = EntityState.Modified;
            db.SaveChanges();
        }

      

    }
}
