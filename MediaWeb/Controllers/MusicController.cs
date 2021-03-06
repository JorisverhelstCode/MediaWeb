﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Database;
using MediaWeb.Domain;
using MediaWeb.Domain.Media;
using MediaWeb.Models.Film;
using MediaWeb.Models.Media.Music;
using MediaWeb.Models.Music;
using MediaWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MediaWeb.Controllers
{
    [Authorize]
    public class MusicController : Controller
    {
        private readonly MediaDbContext _mediaDbContext;
        private readonly UserManager<MediaWebUser> _userManager;
        private readonly IUserDbService _userDbService;

        public MusicController(MediaDbContext context, UserManager<MediaWebUser> userManager, IUserDbService dbService)
        {
            _mediaDbContext = context;
            _userManager = userManager;
            _userDbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            MusicIndexViewModel model = new MusicIndexViewModel();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            model.Music = new List<MusicIndexListViewModel>();
            var musicFromDb = await _userDbService.GetMusicListForUserAsync(user.Id);
            foreach (var music in musicFromDb)
            {
                model.Music.Add(new MusicIndexListViewModel
                {
                    Id = music.Id,
                    Title = music.Title,
                    Type = "Music"
                });
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            Film filmFromDb = await _mediaDbContext.Films.FindAsync(id);
            MusicDetailViewModel model = new MusicDetailViewModel
            {
                Id = filmFromDb.Id,
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
            MusicEditViewModel model = new MusicEditViewModel
            {
                Id = filmFromDb.Id,
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

            return View(new MusicDeleteViewModel() { Id = filmFromDb.Id});
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
            MusicCreateViewModel model = new MusicCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MusicCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Music toBeAddedMusic = new Music
                {
                    Artist = model.Artist,
                    ReleaseDate = model.ReleaseDate,
                    Genre = model.Genre,
                    Title = model.Title,
                    Url = model.Url
                };

                var user = await _userManager.GetUserAsync(HttpContext.User);
                _mediaDbContext.MusicList.Add(toBeAddedMusic);
                await _mediaDbContext.SaveChangesAsync();
                UserMusic newConnection = new UserMusic
                {
                    User = user,
                    UserId = user.Id,
                    Music = toBeAddedMusic,
                    MusicId = toBeAddedMusic.Id
                };
                _mediaDbContext.UserMusicList.Add(newConnection);
                await _mediaDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}