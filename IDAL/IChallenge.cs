using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IChallenge
    {
        IEnumerable<Challenge> GetChallenge();
        Challenge GetChallengeById(int? id);
        IQueryable<UserDati> GetUserDatiByChallengeId(int id);
        IEnumerable<Challenge> SuijiChallengeByKid(int kid);
        void RemoveChallenge(Challenge challenge);
        void AddChallenge(Challenge challenge);
        void EditChallenge(Challenge challenge);

        void RemoveRangeUserDati(IQueryable<UserDati> UserDati);

    }
}
