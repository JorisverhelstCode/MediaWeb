using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Database;
using MediaWeb.Domain;
using MediaWeb.Models.PodCast;
using Microsoft.AspNetCore.Mvc;

namespace MediaWeb.Controllers
{
    public class PodCastController : Controller
    {
        private readonly MediaDbContext _mediaDbContext;

        public PodCastController(MediaDbContext context)
        {
            _mediaDbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            PodCast podCastFromDb = await _mediaDbContext.PodCasts.FindAsync(id);
            PodCastDetailViewModel model = new PodCastDetailViewModel
            {
                Id = podCastFromDb.Id,
                ReleaseDate = podCastFromDb.ReleaseDate,
                Title = podCastFromDb.Title,
                Url = podCastFromDb.Url,
                Guest = podCastFromDb.Guest,
                Host = podCastFromDb.Host
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            PodCast podCastFromDb = await _mediaDbContext.PodCasts.FindAsync(id);
            PodCastEditViewmodel model = new PodCastEditViewmodel
            {
                Id = podCastFromDb.Id,
                ReleaseDate = podCastFromDb.ReleaseDate,
                Title = podCastFromDb.Title,
                Url = podCastFromDb.Url,
                Guest = podCastFromDb.Guest
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PodCastEditViewmodel vm)
        {
            if (!TryValidateModel(vm))
            {
                return View(vm);
            }

            PodCast domainFilm = await _mediaDbContext.PodCasts.FindAsync(id);

            domainFilm.Title = vm.Title;
            domainFilm.Guest = vm.Guest;
            domainFilm.ReleaseDate = vm.ReleaseDate;
            domainFilm.Url = vm.Url;
            domainFilm.Host = vm.Host;

            _mediaDbContext.Update(domainFilm);

            await _mediaDbContext.SaveChangesAsync();

            return RedirectToAction("Detail", new { Id = id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Film filmFromDb = await _mediaDbContext.Films.FindAsync(id);

            return View(new PodCast() { Id = filmFromDb.Id });
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Film filmToDelete = await _mediaDbContext.Films.FindAsync(id);
            _mediaDbContext.Films.Remove(filmToDelete);
            await _mediaDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}