﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Database;
using MediaWeb.Domain;
using MediaWeb.Domain.Media;
using MediaWeb.Models.Media.Serie;
using MediaWeb.Services;
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
        private readonly IUserDbService _userDbService;

        public SerieController(MediaDbContext context, UserManager<MediaWebUser> userManager, IUserDbService dbService)
        {
            _mediaDbContext = context;
            _userManager = userManager;
            _userDbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SerieIndexViewModel model = new SerieIndexViewModel();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            model.Series = new List<SerieIndexListViewModel>();
            var seriesFromDb = await _userDbService.GetSeriesForUserAsync(user.Id);
            foreach (var serie in seriesFromDb)
            {
                model.Series.Add(new SerieIndexListViewModel
                {
                    Id = serie.Id,
                    Title = serie.Title,
                    Type = "Serie"
                });
            }
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
        public async Task<IActionResult> Edit(SerieEditViewModel vm)
        {
            if (!TryValidateModel(vm))
            {
                return View(vm);
            }

            Serie domainSerie = await _mediaDbContext.Series.FindAsync(vm.Id);

            domainSerie.Title = vm.Title;
            domainSerie.Episode = vm.Episode;
            domainSerie.ReleaseDate = vm.ReleaseDate;
            domainSerie.Url = vm.Url;
            domainSerie.Producer = vm.Producer;

            _mediaDbContext.Update(domainSerie);

            await _mediaDbContext.SaveChangesAsync();

            return RedirectToAction("Detail", new { Id = vm.Id });
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
                _mediaDbContext.Series.Add(toBeAddedSerie);
                await _mediaDbContext.SaveChangesAsync();
                UserSerie newConnection = new UserSerie
                {
                    User = user,
                    UserId = user.Id,
                    Serie = toBeAddedSerie,
                    SerieId = toBeAddedSerie.Id
                };
                _mediaDbContext.UserSeries.Add(newConnection);
                await _mediaDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}