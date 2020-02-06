using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide.API.Models
{
    public class User
    {
        public User()
        {
            //referans tip olduğu için newlememiz lazım!
            Cities = new List<City>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }

        //db'de hashleri varbinary olarak tuttuğumuz için byte[] tipinde tanımladık.
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        //bir kullanıcı birden fazla şehir ekleyebilir.
        public List<City> Cities { get; set; }
    }
}
