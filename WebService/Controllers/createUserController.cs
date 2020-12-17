using System;
using System.Collections.Generic;
using AutoMapper;
using DataServiceLib;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [ApiController]
    //  [Route("api/Titles")]
    [Route("User")]
    public class createUserController : ControllerBase //opsættelse af create user
    {
        //henter dataservice og mapper
        DataService _dataService;
        private readonly IMapper _mapper;
        public createUserController(DataService dataService, IMapper mapper) 
        {
            _dataService = dataService;
            _mapper = mapper;
        }


        [HttpPost("CreateUser")] //laver mapping til den rigtige funktion
        public IActionResult createUsers(UserCreationDto userCreationDto)
        {
            var user = _mapper.Map<User>(userCreationDto);
            _dataService.Createuser(user);
            return Ok();
        }
    }
}