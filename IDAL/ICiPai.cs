﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface  ICiPai
    {
        IEnumerable<CiPai> GetCiPai();
        CiPai GetCiPaiById(int? id);
     
        void RemoveCiPai(CiPai cipai);
        void AddCiPai(CiPai cipai);
        void EditCiPai(CiPai cipai);     

    }
}
