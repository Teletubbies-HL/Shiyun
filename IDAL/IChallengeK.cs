using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  IChallengeK
    {
        IEnumerable<ChallengeK> GetChallengeK();
        ChallengeK GetChallengeKById(int? id);

        void RemoveChallengeK(ChallengeK challengek);
        void AddChallengeK(ChallengeK challengek);
        void EditChallengeK(ChallengeK challengek);
    }
}
