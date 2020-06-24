﻿using System;
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

        [HttpGet]
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
        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Film filmFromDb = await _mediaDbContext.Films.FindAsync(id);
            FilmEditViewModel model = new FilmEditViewModel
            {
                Id = filmFromDb.Id,
                Producer = filmFromDb.Producer,
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

        public async Task<IActionResult> Delete(int id)
        {
            Film filmFromDb = await _mediaDbContext.Films.FindAsync(id);

            return View(new FilmDeleteViewModel() { Id = filmFromDb.Id, Title = filmFromDb.Title });
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
