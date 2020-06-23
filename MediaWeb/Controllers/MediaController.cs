using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Database;
using Microsoft.AspNetCore.Mvc;

namespace MediaWeb.Controllers
{
    public class MediaController : Controller
    {
        private readonly MediaDbContext _mediaDbContext;

        public MediaController(MediaDbContext context)
        {
            _mediaDbContext = context;
        }


        public IActionResult Index()
        {

            return View();
        }
    }
}