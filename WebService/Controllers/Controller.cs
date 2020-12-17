using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/Titles")]
    public class Controller : ControllerBase
    {
        DataService _dataService;
        private readonly IMapper _mapper;

        public Controller(DataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

            [HttpGet]
            public IActionResult GetTitles()
            {
                if (Program.CurrentUser == null)
                {
                    return Unauthorized();
                }
                try
                {
                    var title = _dataService.Gettitle(Program.CurrentUser.userid);

                    return Ok(_mapper.Map<IEnumerable<TitleDto>>(title));
                }
                catch (ArgumentException)
                {
                    return Unauthorized();
                }

            }

        [HttpGet("search/{arg}", Name = nameof(GetByName))]
        public IActionResult GetByName(string arg, int page = 0, int pageSize = 10)
        {
            var searchitems = _dataService.SearchMovie(arg, page, pageSize);
            //var si = _mapper.Map<IEnumerable<findingmovieDto>>(searchitems);
            var numberOfMovies = _dataService.GetSearchMovieCount(arg);
            //GetSearchCount();//_dataService.SearchNum(id);//amount of items in search
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




        [HttpGet("name/{arg}", Name = nameof(GetByName3))]
        public IActionResult GetByName3(string arg, int page = 0, int pageSize = 10)
        {
            var searchitems = _dataService.SearchName(arg, page, pageSize);
            //var si = _mapper.Map<IEnumerable<findingmovieDto>>(searchitems);
            var numberOfMovies = _dataService.GetSearchNameCount(arg);
            //GetSearchCount();//_dataService.SearchNum(id);//amount of items in search
            var pages = (int)Math.Ceiling((double)numberOfMovies / pageSize);
            var prev = (string)null;
            if (page > 0)
            {
                prev = Url.Link(nameof(GetByName3), new { arg, page = page - 1, pageSize });
            }

            var next = (string)null;
            if (page < pages - 1)
            {
                next = Url.Link(nameof(GetByName3), new { arg, page = page + 1, pageSize });
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


        [HttpPost("CreateUser")]
            public IActionResult createUsers(UserCreationDto userCreationDto)
            {
                var user = _mapper.Map<User>(userCreationDto);
                _dataService.Createuser(user);
            return Ok();
            }


        }
    } 
