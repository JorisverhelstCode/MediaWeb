using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Database;
using MediaWeb.Domain;
using MediaWeb.Models.PodCast;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            PodCast podCastFromDb = await _mediaDbContext.PodCasts.FindAsync(id);

            return View(new PodCast() { Id = podCastFromDb.Id });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            PodCast podCastToDelete = await _mediaDbContext.PodCasts.FindAsync(id);
            _mediaDbContext.PodCasts.Remove(podCastToDelete);
            await _mediaDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}