using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Database;
using MediaWeb.Domain;
using MediaWeb.Models.Film;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediaWeb.Controllers
{
    public class FilmController : Controller
    {
        private readonly MediaDbContext _mediaDbContext;

        public FilmController(MediaDbContext context)
        {
            _mediaDbContext = context;
        }

        public async Task<IActionResult> Detail(int id)
        {
            Film filmFromDb = await _mediaDbContext.Films.FindAsync(id);
            FilmDetailViewModel model = new FilmDetailViewModel
            {
                Id = filmFromDb.Id,
                Producer = filmFromDb.Producer,
                ReleaseDate = filmFromDb.ReleaseDate,
                Title = filmFromDb.Title,
                Url = filmFromDb.Url
            };

            return View(model);
        }
    }
}