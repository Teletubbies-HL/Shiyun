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
   public class ChallengeKManager
    {
        IChallengeK ichallengek = DataAccess.CreateChallengeK();
        public IEnumerable<ChallengeK> GetChallengeK()
        {
            var challengeks = ichallengek.GetChallengeK();
            return challengeks;
        }
        public ChallengeK GetChallengeKById(int? id)
        {
            ChallengeK challengek = ichallengek.GetChallengeKById(id);
            return challengek;
        }
       
        public void RemoveGoods(ChallengeK challengek)
        {
            ichallengek.RemoveChallengeK(challengek);

        }
        public void AddGoods(ChallengeK challengek)
        {
            ichallengek.AddChallengeK(challengek);

        }
        public void EditGoods(ChallengeK challengek)
        {
            ichallengek.EditChallengeK(challengek);

        }
       
    }
}
