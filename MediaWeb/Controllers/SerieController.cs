using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Database;
using MediaWeb.Domain;
using MediaWeb.Models.Media.Serie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MediaWeb.Controllers
{
    [Authorize]
    public class SerieController : Controller
    {
        private readonly MediaDbContext _mediaDbContext;
        private readonly UserManager<MediaWebUser> _userManager;

        public SerieController(MediaDbContext context, UserManager<MediaWebUser> userManager)
        {
            _mediaDbContext = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SerieIndexViewModel model = new SerieIndexViewModel();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            model.Series = new List<SerieIndexListViewModel>();
            model.Series.AddRange(user.FilmList
                .Select(film => new SerieIndexListViewModel
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
            Serie serieFromDb = await _mediaDbContext.Series.FindAsync(id);
            SerieDetailViewModel model = new SerieDetailViewModel
            {
                Id = serieFromDb.Id,
                Producer = serieFromDb.Producer,
                ReleaseDate = serieFromDb.ReleaseDate,
                Title = serieFromDb.Title,
                Url = serieFromDb.Url,
                Episode = serieFromDb.Episode
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Serie serieFromDb = await _mediaDbContext.Series.FindAsync(id);
            SerieEditViewModel model = new SerieEditViewModel
            {
                Id = serieFromDb.Id,
                Producer = serieFromDb.Producer,
                ReleaseDate = serieFromDb.ReleaseDate,
                Title = serieFromDb.Title,
                Url = serieFromDb.Url,
                Episode = serieFromDb.Episode
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SerieEditViewModel vm)
        {
            if (!TryValidateModel(vm))
            {
                return View(vm);
            }

            Serie domainSerie = await _mediaDbContext.Series.FindAsync(id);

            domainSerie.Title = vm.Title;
            domainSerie.Episode = vm.Episode;
            domainSerie.ReleaseDate = vm.ReleaseDate;
            domainSerie.Url = vm.Url;
            domainSerie.Producer = vm.Producer;

            _mediaDbContext.Update(domainSerie);

            await _mediaDbContext.SaveChangesAsync();

            return RedirectToAction("Detail", new { Id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Serie serieFromDb = await _mediaDbContext.Series.FindAsync(id);

            return View(new SerieDeleteViewModel() { Id = serieFromDb.Id, Title = serieFromDb.Title });
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Serie serieToDelete = await _mediaDbContext.Series.FindAsync(id);
            _mediaDbContext.Series.Remove(serieToDelete);
            await _mediaDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            SerieCreateViewModel model = new SerieCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SerieCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Serie toBeAddedSerie = new Serie
                {
                    Episode = model.Episode,
                    ReleaseDate = model.ReleaseDate,
                    Producer = model.Producer,
                    Title = model.Title,
                    Url = model.Url
                };

                var user = await _userManager.GetUserAsync(HttpContext.User);
                user.SerieList.Add(toBeAddedSerie);
                _mediaDbContext.Series.Add(toBeAddedSerie);
                await _mediaDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}