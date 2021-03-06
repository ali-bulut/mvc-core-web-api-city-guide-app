﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityGuide.API.Dtos;
using CityGuide.API.Models;

namespace CityGuide.API.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            //iki classtaki isimleri aynı olanları direkt birbirine aktarırken ismi farklı olanları aşağıdaki gibi
            //tek tek yazmamız(yani profil eklememiz) gerekiyor.
            CreateMap<City, CityForListDto>()
                .ForMember(dest=>dest.PhotoUrl, opt =>
                {
                    //eğer ana fotoğrafsa url'ini çek ve PhotoUrl propertysine yaz.
                    opt.MapFrom(src=>src.Photos.FirstOrDefault(p=>p.IsMain).Url);
                });

            CreateMap<City, CityForDetailDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<Photo, PhotoForReturnDto>();

        }
    }
}
