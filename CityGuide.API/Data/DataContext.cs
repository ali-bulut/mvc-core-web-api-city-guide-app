using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityGuide.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CityGuide.API.Data
{
    public class DataContext:DbContext
    {
        //Database'i bağlama
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        //Database'deki tabloları bağlama
        public DbSet<Value> Values { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
