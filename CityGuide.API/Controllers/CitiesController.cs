using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityGuide.API.Data;
using CityGuide.API.Dtos;
using CityGuide.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityGuide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IAppRepository _repository;
        private IMapper _mapper;

        public CitiesController(IAppRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult GetCities()
        {
            //bu şekilde her şehrin sadece isim datasını göndeririz.
            //var cities = _repository.GetCities().Select(c=>c.Name);

            //bu şekilde mapper yaparak sadece belirli dataları göndeririz.
            //var cities = _repository.GetCities().Select(c => new CityForListDto
            //{
            //    Name = c.Name,
            //    Id = c.Id,
            //    Description = c.Description,
            //    PhotoUrl = c.Photos.FirstOrDefault(p=>p.IsMain==true).Url
            //}).ToList();

            //bu şekilde de automapper yaparak uğraşmadan belirli dataları otomatik olarak göndeririz.
            var cities = _repository.GetCities();
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);

            return Ok(citiesToReturn);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody]City city)
        {
            _repository.Add(city);
            _repository.SaveAll();
            return Ok(city);
        }

        [HttpGet]
        [Route("Detail/{id}")]
        public IActionResult GetCity(int id)
        {
            var city = _repository.GetCity(id);
            var cityToReturn = _mapper.Map<CityForDetailDto>(city);

            return Ok(cityToReturn);
        }

        [HttpGet]
        [Route("Photos/{cityId}")]
        public IActionResult GetPhotosByCity(int cityId)
        {
            var photos = _repository.GetPhotosByCity(cityId);
            return Ok(photos);
        }

    }
}