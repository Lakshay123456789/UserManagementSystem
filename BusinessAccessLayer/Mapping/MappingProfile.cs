using AutoMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace BusinessAccessLayer.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            CreateMap<UserDto, User>();

        }
    }
}
