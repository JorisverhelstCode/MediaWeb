using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediaWeb.Database;
using MediaWeb.Domain;
using MediaWeb.Domain.Media;
using MediaWeb.Models;
using MediaWeb.Models.Media;
using MediaWeb.Models.Media.Film;
using MediaWeb.Models.Media.Music;
using MediaWeb.Models.Media.PodCast;
using MediaWeb.Models.Media.Serie;
using MediaWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MediaWeb.Controllers
{
    [Authorize]
    public class MediaController : Controller
    {
        private readonly UserManager<MediaWebUser> _userManager;
        private readonly UserDbService _userDbService;
        private readonly MediaDbContext _mediaDbContext;

        public MediaController(MediaDbContext context, UserManager<MediaWebUser> userManager, UserDbService dbService)
        {
            _mediaDbContext = context;
            _userManager = userManager;
            _userDbService = dbService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            MediaIndexViewModel model = new MediaIndexViewModel();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            model.MediaList = new List<MediaIndexListViewModel>();
            var filmsFromDb = await _userDbService.GetFilmsForUserAsync(userId);
            foreach (var film in filmsFromDb)
            {
                model.MediaList.Add(new FilmIndexListViewModel
                {
                    Id = film.Id,
                    Title = film.Title,
                    Type = "Film"
                });
            }
            var podCastsFromDb = await _userDbService.GetPodCastsForUserAsync(userId);
            foreach (var podCast in podCastsFromDb)
            {
                model.MediaList.Add(new PodCastIndexListViewModel
                {
                    Id = podCast.Id,
                    Title = podCast.Title,
                    Type = "PodCast"
                });
            }
            var musicFromDb = await _userDbService.GetMusicListForUserAsync(userId);
            foreach (var music in musicFromDb)
            {
                model.MediaList.Add(new MusicIndexListViewModel
                {
                    Id = music.Id,
                    Title = music.Title,
                    Type = "Music"
                });
            }
            var seriesFromDb = await _userDbService.GetSeriesForUserAsync(userId);
            foreach (var serie in seriesFromDb)
            {
                model.MediaList.Add(new SerieIndexListViewModel
                {
                    Id = serie.Id,
                    Title = serie.Title,
                    Type = "Serie"
                });
            }
            model.PlayLists = user.PlayLists;
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Detail(MediaIndexListViewModel model)
        {
            switch (model.Type)
            {
                case "Film":
                    return RedirectToAction("Detail", "FilmController", model.Id);
                case "PodCast":
                    return RedirectToAction("Detail", "PodCastController", model.Id);
                case "Serie":
                    return RedirectToAction("Detail", "SerieController", model.Id);
                case "Music":
                    return RedirectToAction("Detail", "MusicController", model.Id);
                default:
                    return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(MediaIndexListViewModel model)
        {
            switch (model.Type)
            {
                case "Film":
                    return RedirectToAction("Edit", "FilmController", model.Id);
                case "PodCast":
                    return RedirectToAction("Edit", "PodCastController", model.Id);
                case "Serie":
                    return RedirectToAction("Edit", "SerieController", model.Id);
                case "Music":
                    return RedirectToAction("Edit", "MusicController", model.Id);
                default:
                    return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete(MediaIndexListViewModel model)
        {
            switch (model.Type)
            {
                case "Film":
                    return RedirectToAction("Delete", "FilmController", model.Id);
                case "PodCast":
                    return RedirectToAction("Delete", "PodCastController", model.Id);
                case "Serie":
                    return RedirectToAction("Delete", "SerieController", model.Id);
                case "Music":
                    return RedirectToAction("Delete", "MusicController", model.Id);
                default:
                    return View(model);
            }
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}