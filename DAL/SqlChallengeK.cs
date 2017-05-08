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
    public class SqlChallengeK:IChallengeK
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<ChallengeK> GetChallengeK()
        {
            var challengek = db.ChallengeK.ToList();
            return challengek;
        }
        public ChallengeK GetChallengeKById(int? id)
        {
            ChallengeK challengek = db.ChallengeK.Find(id);
            return challengek;
        }
       

        public void RemoveChallengeK(ChallengeK challengek)
        {
            db.ChallengeK.Remove(challengek);
            db.SaveChanges();
        }
        public void AddChallengeK(ChallengeK challengek)
        {
            db.ChallengeK.Add(challengek);
            db.SaveChanges();
        }
        public void EditChallengeK(ChallengeK challengek)
        {
            db.Entry(challengek).State = EntityState.Modified;
            db.SaveChanges();
        }

       
    }
}
