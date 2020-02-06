using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityGuide.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CityGuide.API.Data
{
    public class AppRepository:IAppRepository
    {
        private DataContext _context;

        public AppRepository(DataContext context)
        {
            _context = context;
        }


        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveAll()
        {
            //savechanges methodu etkilenen kayıt sayısını döndürür.
            return _context.SaveChanges() > 0;
        }

        public List<City> GetCities()
        {
            //include ile city'nin fotoğraflarını da getirmesini istedik.
            var cities = _context.Cities.Include(c=>c.Photos).ToList();
            return cities;
        }

        public List<Photo> GetPhotosByCity(int cityId)
        {
            var photos = _context.Photos.Where(p => p.CityId == cityId).ToList();
            return photos;
        }

        public City GetCity(int id)
        {
            var city = _context.Cities.Include(c => c.Photos).SingleOrDefault(c => c.Id == id);
            return city;
        }

        public Photo GetPhoto(int id)
        {
            var photo = _context.Photos.SingleOrDefault(p => p.Id == id);
            return photo;
        }
    }
}
