﻿using MediaWeb.Domain;
using MediaWeb.Domain.Media;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Database
{
    public class MediaDbContext : IdentityDbContext<MediaWebUser>
    {
        public MediaDbContext(DbContextOptions<MediaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Music> MusicList { get; set; }
        public DbSet<PodCast> PodCasts { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<UserFilm> UserFilms { get; set; }
        public DbSet<UserSerie> UserSeries { get; set; }
        public DbSet<UserPodCast> UserPodCasts { get; set; }
        public DbSet<UserMusic> UserMusicList { get; set; }
    }
}
