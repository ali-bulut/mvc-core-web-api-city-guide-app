using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide.API.Models
{
    public class City
    {
        public City()
        {
            //referans tip olduğu için newlememiz lazım!
            Photos = new List<Photo>();
            //User'ı newlemeye gerek yok.
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //şehrin birden fazla fotosu olabilir o yüzden liste.
        public List<Photo> Photos { get; set; }

        //şehri sadece 1 kullanıcı ekleyebilir o yüzden liste değil.
        public User User { get; set; }
    }
}
