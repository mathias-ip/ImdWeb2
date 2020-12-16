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

            [HttpGet("search/{id}")]
            public IActionResult getByName(string id)
            {
                if (Program.CurrentUser == null)
                {
                    return Unauthorized();
                }
                try
                {
                    var result = _dataService.Search(id);
                    return Ok(result);
                }
                catch (ArgumentException)
                {
                    return Unauthorized();
                }
            }


            [HttpGet("name/{id2}")]
            public IActionResult getByName3(string id2)
            {

                var result = _dataService.Search2(id2);
                Console.WriteLine(result.Count());
                return Ok(result);

            }

            [HttpGet("structuredSearch/{id}")]
            public IActionResult getByName2(string id)
            {
                var result = _dataService.StringSearch("", "see", "", "Mads Mikkelsen", "123");
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
