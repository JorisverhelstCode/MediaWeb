using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Database;
using MediaWeb.Domain;
using MediaWeb.Domain.Media;
using MediaWeb.Models.Film;
using MediaWeb.Models.Media.Film;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediaWeb.Controllers
{
    [Authorize]
    public class FilmController : Controller
    {
        private readonly MediaDbContext _mediaDbContext;
        private readonly UserManager<MediaWebUser> _userManager;

        public FilmController(MediaDbContext context, UserManager<MediaWebUser> userManager)
        {
            _mediaDbContext = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            FilmIndexViewModel model = new FilmIndexViewModel();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userFilms = _mediaDbContext.UserFilms.Where(x => x.UserId == user.Id);
            var FilmJoin =
                from film in _mediaDbContext.Films
                join userFilm in userFilms on film.Id equals userFilm.FilmId into films
                select new { Id = film.Id, Title = film.Title };
            model.Films = new List<FilmIndexListViewModel>();
            model.Films.AddRange(FilmJoin
                .Select(film => new FilmIndexListViewModel
                {
                    Id = film.Id,
                    Title = film.Title,
                    Type = "Film"
                }));
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            Film filmFromDb = await _mediaDbContext.Films.FindAsync(id);
            FilmDetailViewModel model = new FilmDetailViewModel
            {
                Id = filmFromDb.Id,
                Producer = filmFromDb.Producer,
                ReleaseDate = filmFromDb.ReleaseDate,
                Title = filmFromDb.Title,
                Url = filmFromDb.Url
            };

            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Film filmFromDb = await _mediaDbContext.Films.FindAsync(id);
            FilmEditViewModel model = new FilmEditViewModel
            {
                Id = filmFromDb.Id,
                Producer = filmFromDb.Producer,
                ReleaseDate = filmFromDb.ReleaseDate,
                Title = filmFromDb.Title,
                Url = filmFromDb.Url
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FilmEditViewModel vm)
        {
            if (!TryValidateModel(vm))
            {
                return View(vm);
            }

            Film domainFilm = await _mediaDbContext.Films.FindAsync(id);

            domainFilm.Title = vm.Title;
            domainFilm.Description = vm.Description;
            domainFilm.ReleaseDate = vm.ReleaseDate;
            domainFilm.Url = vm.Url;
            domainFilm.Producer = vm.Producer;

            _mediaDbContext.Update(domainFilm);

            await _mediaDbContext.SaveChangesAsync();

            return RedirectToAction("Detail", new { Id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Film filmFromDb = await _mediaDbContext.Films.FindAsync(id);

            return View(new FilmDeleteViewModel() { Id = filmFromDb.Id, Title = filmFromDb.Title });
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Film filmToDelete = await _mediaDbContext.Films.FindAsync(id);
            _mediaDbContext.Films.Remove(filmToDelete);
            await _mediaDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            FilmCreateViewModel model = new FilmCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FilmCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Film toBeAddedFilm = new Film
                {
                    Description = model.Description,
                    ReleaseDate = model.ReleaseDate,
                    Genre = model.Genre,
                    Producer = model.Producer,
                    Title = model.Title,
                    Url = model.Url
                };
                
                var user = await _userManager.GetUserAsync(HttpContext.User);
                _mediaDbContext.Films.Add(toBeAddedFilm);
                await _mediaDbContext.SaveChangesAsync();
                UserFilm newConnection = new UserFilm
                {
                    User = user,
                    UserId = user.Id,
                    Film = toBeAddedFilm,
                    FilmId = toBeAddedFilm.Id
                };
                _mediaDbContext.UserFilms.Add(newConnection);
                await _mediaDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            
            return View(model);
        }
    }
}
