using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Database;
using MediaWeb.Domain;
using MediaWeb.Models.Media.Serie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediaWeb.Controllers
{
    [Authorize]
    public class SerieController : Controller
    {
        private readonly MediaDbContext _mediaDbContext;

        public SerieController(MediaDbContext context)
        {
            _mediaDbContext = context;
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
    }
}