using System;
using System.Collections.Generic;
using AutoMapper;
using DataServiceLib;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [ApiController]
    [Route("Search")]
    public class searchController : ControllerBase //Controller til søgefunktionen
    {
        DataService _dataService;
        private readonly IMapper _mapper;

        public searchController(DataService dataService, IMapper mapper) //Mapper dataservice laget til brug af auth testing
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        

        [HttpGet("search/{arg}", Name = nameof(GetByMovie))]
        public IActionResult GetByMovie(string arg, int page = 0, int pageSize = 10)
        {
            //Henter data fra dataservice til brug i film
            var searchitems = _dataService.SearchMovie(arg, page, pageSize);
            var numberOfMovies = _dataService.GetSearchMovieCount(arg);
            var pages = (int)Math.Ceiling((double)numberOfMovies / pageSize); //henter film og indsætter side størrelse ud for mængden af film
            var prev = (string)null;
            if (page > 0)
            {
                prev = Url.Link(nameof(GetByMovie), new { arg, page = page - 1, pageSize }); //Side skift, tilbage
            }

            var next = (string)null;
            if (page < pages - 1)
            {
                next = Url.Link(nameof(GetByMovie), new { arg, page = page + 1, pageSize }); //Side skift, frem
                Console.WriteLine(next);
            }

            var result = new
            {
                pageSizes = new int[] { 5, 10, 15, 20 },
                count = numberOfMovies,
                pages,
                prev,
                next,
                searchitems
            };

            return Ok(result);

        }




        [HttpGet("name/{arg}", Name = nameof(GetByName))] 
        public IActionResult GetByName(string arg, int page = 0, int pageSize = 10) // Henter sider for navne
        {
            var searchitems = _dataService.SearchName(arg, page, pageSize);
            var numberOfMovies = _dataService.GetSearchNameCount(arg);
            var pages = (int)Math.Ceiling((double)numberOfMovies / pageSize);
            var prev = (string)null;
            if (page > 0)
            {
                prev = Url.Link(nameof(GetByName), new { arg, page = page - 1, pageSize });
            }

            var next = (string)null;
            if (page < pages - 1)
            {
                next = Url.Link(nameof(GetByName), new { arg, page = page + 1, pageSize });
                Console.WriteLine(next);
            }

            var result = new
            {
                pageSizes = new int[] { 5, 10, 15, 20 },
                count = numberOfMovies,
                pages,
                prev,
                next,
                searchitems
            };

            return Ok(result);

        }
        }
    } 
