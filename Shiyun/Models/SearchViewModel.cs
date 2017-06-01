using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Shiyun.Models
{
    public class SearchViewModel
    {
        public IEnumerable<UserInfo> UserInfo1 { get; set; }
        public IQueryable<Shi> Shi1 { get; set; }
        public IEnumerable<Ci> Ci1 { get; set; }
        public IEnumerable<Post> Post1 { get; set; }
        public IEnumerable<Goods> Goods1 { get; set; }
        public IEnumerable<Author> Author1 { get; set; }
        public IEnumerable<Time> Time1 { get; set; }
        public IEnumerable<Video> Video1 { get; set; }
    }
}