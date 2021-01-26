using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServiceLib;
using AutoMapper;

namespace WebService.Models
{
    public class UsersDto
    {
        public int? userid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
    public class Userprofile : Profile
    {
        public Userprofile()
        {
            CreateMap <User, UsersDto>();
        }
    }
}
