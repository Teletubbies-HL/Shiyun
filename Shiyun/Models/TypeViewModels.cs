using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Shiyun.Models
{
    public class TypeViewModels
    {    
        public IEnumerable<ShiType> Type { get; set; }
        public IEnumerable<Shi> TypeShi { get; set; }
        public IEnumerable<View_ShitypeA> AllShi { get; set; }

    }

}