using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Database;
using MediaWeb.Domain;
using MediaWeb.Domain.Media;
using MediaWeb.Models.Media.PodCast;
using MediaWeb.Models.PodCast;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MediaWeb.Controllers
{
    [Authorize]
    public class PodCastController : Controller
    {
        private readonly MediaDbContext _mediaDbContext;
        private readonly UserManager<MediaWebUser> _userManager;

        public PodCastController(MediaDbContext context, UserManager<MediaWebUser> userManager)
        {
            _mediaDbContext = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            PodCastIndexViewModel model = new PodCastIndexViewModel();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userPodCasts = _mediaDbContext.UserPodCasts.Where(x => x.UserId == user.Id);
            var PodCastJoin =
                from podCast in _mediaDbContext.PodCasts
                join userPodCast in userPodCasts on podCast.Id equals userPodCast.PodCastId into podcasts
                select new { Id = podCast.Id, Title = podCast.Title };
            model.PodCasts = new List<PodCastIndexListViewModel>();
            model.PodCasts.AddRange(PodCastJoin
                .Select(podCast => new PodCastIndexListViewModel
                {
                    Id = podCast.Id,
                    Title = podCast.Title,
                    Type = "PodCast"
                }));
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
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
            PodCast podCastFromDb = await _mediaDbContext.PodCasts.FindAsync(id);

            return View(new PodCast() { Id = podCastFromDb.Id });
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            PodCast podCastToDelete = await _mediaDbContext.PodCasts.FindAsync(id);
            _mediaDbContext.PodCasts.Remove(podCastToDelete);
            await _mediaDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            PodCastCreateViewModel model = new PodCastCreateViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PodCastCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                PodCast toBeAddedPodCast = new PodCast
                {
                    Guest = model.Guest,
                    ReleaseDate = model.ReleaseDate,
                    Host = model.Host,
                    Title = model.Title,
                    Url = model.Url
                };

                var user = await _userManager.GetUserAsync(HttpContext.User);
                _mediaDbContext.PodCasts.Add(toBeAddedPodCast);
                await _mediaDbContext.SaveChangesAsync();
                UserPodCast newConnection = new UserPodCast
                {
                    User = user,
                    UserId = user.Id,
                    PodCast = toBeAddedPodCast,
                    PodCastId = toBeAddedPodCast.Id
                };
                _mediaDbContext.UserPodCasts.Add(newConnection);
                await _mediaDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}