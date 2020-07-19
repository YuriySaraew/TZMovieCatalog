using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovCat.Models;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Linq;

namespace MovCat.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        MovieContext db;
        UserManager<AppUser> _userManager;
        IWebHostEnvironment _appEnvironment;

        public UserController(MovieContext context, IWebHostEnvironment appEnvironment, UserManager<AppUser> userManager)
        {
            db = context;
            _appEnvironment = appEnvironment;
            _userManager = userManager;
        }

        //INDEX
        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal _currentUser = this.User;
            MovieUser movUser = await db.MovieUsers.FirstOrDefaultAsync(p => p.Login == _currentUser.Identity.Name);
            var movies = db.Movies.Where(p => p.userID == movUser.Id).ToList();
            return View(movies);
        }

        //EDIT
        public IActionResult Edit(int? id) => View(db.Movies.FirstOrDefault(p => p.Id == id));

        [HttpPost]
        public IActionResult Edit(IFormFile uploadedFile, Movie movie)
        {
            ClaimsPrincipal _currentUser = this.User;
            MovieUser movUser = db.MovieUsers.FirstOrDefault(p => p.Login == _currentUser.Identity.Name);

            string path = "/Files/" + uploadedFile.FileName;
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                uploadedFile.CopyTo(fileStream);
            }

            if (ModelState.IsValid)
            {
                if (movie.Id == 0)
                {

                    db.Movies.Add(new Movie
                    {
                        Name = movie.Name,
                        Description = movie.Description,
                        CreatedYear = movie.CreatedYear,
                        Director = movie.Director,
                        userID = movUser.Id,
                        FilePath = path
                    });
                }
                else
                {
                    Movie dbEntry = db.Movies.FirstOrDefault(p => p.Id == movie.Id);
                    if (dbEntry != null)
                    {
                        dbEntry.Name = movie.Name;
                        dbEntry.Description = movie.Description;
                        dbEntry.CreatedYear = movie.CreatedYear;
                        dbEntry.Director = movie.Director;
                        dbEntry.userID = movie.userID;
                        dbEntry.FilePath = path;
                    }
                }
                db.SaveChanges();
                TempData["message"] = $"Фильм успешно добавлен";
                return RedirectToAction("Index", "User");
            }
            else
            {
                return View(movie);
            }
        }

        //Create
        [HttpGet]
        public IActionResult Create() => View("Edit", new Movie());
        //Delete
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            Movie dbEntry = db.Movies.FirstOrDefault(p => p.Id == id);
            if (dbEntry != null)
            {
                db.Movies.Remove(dbEntry);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "User");
        }
    }
}
