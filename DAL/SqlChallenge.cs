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
    public class SqlChallenge:IChallenge
    {
        ShiyunEntities db = DbContextFactory.CreateDbContext();
        public IEnumerable<Challenge> GetChallenge()
        {
            var challenge = db.Challenge.ToList();
            return challenge;
        }
        public Challenge GetChallengeById(int? id)
        {
            Challenge challenge = db.Challenge.Find(id);
            return challenge;
        }
        public IEnumerable<Challenge> SuijiChallengeByKid(int kid,int tiao)
        {
            var challenge = db.Challenge.Where(c => c.ChallengeK_id == kid).OrderBy(c => Guid.NewGuid()).ToList().Take(tiao);
            return challenge;
        }
        public IQueryable<UserDati> GetUserDatiByChallengeId(int id)
        {
            var UserDati = db.UserDati.Include("Challenge").Where(c => c.Timu_id == id);
            return UserDati;
        }
        
        public void RemoveChallenge(Challenge challenge)
        {
            db.Challenge.Remove(challenge);
            db.SaveChanges();
        }
        public void AddChallenge(Challenge challenge)
        {
            db.Challenge.Add(challenge);
            db.SaveChanges();
        }
        public void AddUserdati(UserDati userDati)
        {
            db.UserDati.Add(userDati);
            db.SaveChanges();
        }
        public void EditChallenge(Challenge challenge)
        {
            db.Entry(challenge).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void RemoveRangeUserDati(IQueryable<UserDati> UserDati)
        {
            db.UserDati.RemoveRange(UserDati);
        }
        
    }
}
