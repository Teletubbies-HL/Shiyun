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
   public class ChallengeManager
    {
        IChallenge ichallenge = DataAccess.CreateChallenge();
        public IEnumerable<Challenge> GetChallenge()
        {
            var challenges = ichallenge.GetChallenge();
            return challenges;
        }
        public Challenge GetChallengeById(int? id)
        {
            Challenge challenge = ichallenge.GetChallengeById(id);
            return challenge;
        }

       public IEnumerable<Challenge> SuijiChallengeByKid(int kid, int tiao)
       {
            var challenge = ichallenge.SuijiChallengeByKid(kid,tiao);
            return challenge;

        }
        public IQueryable<UserDati> GetUserDatiByChallengeId(int id)
        {
            var UserDati = ichallenge.GetUserDatiByChallengeId(id);
            return UserDati;
        }
       
        public void RemoveChallenge(Challenge challenge)
        {
            ichallenge.RemoveChallenge(challenge);

        }
        public void AddChallenge(Challenge challenge)
        {
            ichallenge.AddChallenge(challenge);

        }
        public void EditChallenge(Challenge challenge)
        {
            ichallenge.EditChallenge(challenge);

        }
        public void RemoveRangeUserDati(IQueryable<UserDati> UserDati)
        {
            ichallenge.RemoveRangeUserDati(UserDati);
        }
       
    }
}
