using MediaWeb.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Database
{
    public class MediaDbContext : IdentityDbContext
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
    }
}
