using MovCat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovCat.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Movie> Movies{ get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
