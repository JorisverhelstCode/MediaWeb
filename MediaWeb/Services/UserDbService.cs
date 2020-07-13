using MediaWeb.Database;
using MediaWeb.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace MediaWeb.Services
{
    public interface IUserDbService
    {
        public Task<IEnumerable<Serie>> GetSeriesForUserAsync(string userID);
        public Task<IEnumerable<Film>> GetFilmsForUserAsync(string userID);
        public Task<IEnumerable<PodCast>> GetPodCastsForUserAsync(string userID);
        public Task<IEnumerable<Music>> GetMusicListForUserAsync(string userID);
    }

    public class UserDbService : IUserDbService
    {
        private readonly MediaDbContext _mediaDbContext;

        public UserDbService(MediaDbContext context)
        {
            _mediaDbContext = context;
        }

        public async Task<IEnumerable<Serie>> GetSeriesForUserAsync(string userID)
        {
            return await _mediaDbContext.UserSeries
                .Include(x => x.Serie)
                .Where(x => x.UserId == userID)
                .Select(x => x.Serie).ToListAsync();
        }

        public async Task<IEnumerable<Film>> GetFilmsForUserAsync(string userID)
        {
            return await _mediaDbContext.UserFilms
                .Include(x => x.Film)
                .Where(x => x.UserId == userID)
                .Select(x => x.Film).ToListAsync();
        }

        public async Task<IEnumerable<PodCast>> GetPodCastsForUserAsync(string userID)
        {
            return await _mediaDbContext.UserPodCasts
                .Include(x => x.PodCast)
                .Where(x => x.UserId == userID)
                .Select(x => x.PodCast).ToListAsync();
        }

        public async Task<IEnumerable<Music>> GetMusicListForUserAsync(string userID)
        {
            return await _mediaDbContext.UserMusicList
                .Include(x => x.Music)
                .Where(x => x.UserId == userID)
                .Select(x => x.Music).ToListAsync();
        }
    }
}
