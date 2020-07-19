using MovCat.Models;
using MovCat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MovCat.Controllers
{
    public class HomeController : Controller
    {
        MovieContext db;
        public int PageSize = 4;
        public HomeController(MovieContext context)
        {
            db = context;
        }

        public IActionResult Index(int moviePage = 1) =>
            View(new MoviesListViewModel
            {
                Movies = db.Movies.OrderBy(p => p.Name).Skip((moviePage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo { CurrentPage = moviePage, ItemsPerPage = PageSize, TotalItems = db.Movies.Count() }
            });

        public IActionResult MoviePage(int? id) => View(db.Movies.FirstOrDefault(p => p.Id == id));

    }
}
