using System;
using System.Collections.Generic;
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
        private readonly UserManager<IdentityUser> _userManager;

        public MediaController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var user = (MediaWebUser)await _userManager.GetUserAsync(HttpContext.User);
            MediaIndexViewModel model = new MediaIndexViewModel();
            model.MediaList = new List<MediaIndexListViewModel>();
            foreach (var music in user.MusicList)
            {
                var item = new MusicIndexListViewModel
                {
                    Id = music.Id,
                    Title = music.Title,
                    Type = "Music"
                };
                model.MediaList.Add(item);
            }
            foreach (var podCast in user.PodCastList)
            {
                var item = new PodCastIndexListViewModel
                {
                    Id = podCast.Id,
                    Title = podCast.Title,
                    Type = "PodCast"
                };
                model.MediaList.Add(item);
            }
            foreach (var film in user.FilmList)
            {
                var item = new FilmIndexListViewModel
                {
                    Id = film.Id,
                    Title = film.Title,
                    Type = "Film"
                };
                model.MediaList.Add(item);
            }
            foreach (var serie in user.SerieList)
            {
                var item = new SerieIndexListViewModel
                {
                    Id = serie.Id,
                    Title = serie.Title,
                    Type = "Serie"
                };
                model.MediaList.Add(item);
            }
            foreach (var playList in user.PlayLists)
            {
                model.PlayLists.Add(playList);
            }
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
    }
}