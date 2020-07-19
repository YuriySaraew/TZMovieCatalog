using MovCat.Models;
using System.Collections.Generic;

namespace MovCat.ViewModels
{
    public class MoviesListViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
