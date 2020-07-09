using System;
using System.Collections.Generic;
using System.Linq;
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

        public MediaController(UserManager<MediaWebUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            MediaIndexViewModel model = new MediaIndexViewModel();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            model.MediaList = new List<MediaIndexListViewModel>();
            model.MediaList.AddRange(user.MusicList
                .Select(music => new MusicIndexListViewModel
                {
                    Id = music.Id,
                    Title = music.Title,
                    Type = "Music"
                }));
            model.MediaList.AddRange(user.PodCastList.
                Select(podcast => new PodCastIndexListViewModel
                {
                    Id = podcast.Id,
                    Title = podcast.Title,
                    Type = "PodCast"
                }));
            model.MediaList.AddRange(user.FilmList
                .Select(film => new FilmIndexListViewModel
                {
                    Id = film.Id,
                    Title = film.Title,
                    Type = "Film"
                }));
            model.MediaList.AddRange(user.SerieList
                .Select(serie => new SerieIndexListViewModel
                {
                    Id = serie.Id,
                    Title = serie.Title,
                    Type = "Serie"
                }));
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