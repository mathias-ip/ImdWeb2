using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        DataService _dataService;
        private readonly IMapper _mapper;

        public UsersController(DataService, IMapper mapper)
        {
            DataService _dataService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {

            var Users = _dataService.GetUsers();

            return Ok(_mapper.Map<IEnumerable<UsersDto>>(Users));
        }

        [HttpPost]
        public IActionResult GetUser(LoginDto login)
        {

            var user = _dataService.GetUser(login.username, login.password);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UsersDto>(user));
        }

      

        [HttpGet("searchhistory/{userid}")]
        public IActionResult GetSearchHistory(int? userid)
        {
            var SearchHistory = _dataService.GetSearchHistory(userid);
            if (SearchHistory == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<SearchHistoryDto>>(SearchHistory));
        }
      
    }
}