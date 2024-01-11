using AutoMapper;
using DataAccessLayer.GenericRepositoryClass;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.UserBusinessLayer
{

    public class UserBusinessLayer : IUserBusinessLayer
    {
        private readonly IGenericRepository<User> _genericRepository;
        private readonly IMapper _mapper;
        public UserBusinessLayer(IGenericRepository<User> genericRepository, IMapper mapper)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }
        public async Task<IEnumerable<User>> GetMethod()
        {
            return await _genericRepository.GetAll();
        }
        public async Task<User> GetByIdUser(Guid Id)
        {
            return await _genericRepository.GetById(Id);
        }
        public async Task InsertMethod(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _genericRepository.Insert(user);
        }

        public async Task DeleteMethod(Guid obj)
        {
            await _genericRepository.Delete(obj);
        }

        public async Task UpdateMethod(UserDto userDto, Guid Id)
        {
            var user = await _genericRepository.GetById(Id);

            if (user != null)
            {
                _mapper.Map(userDto, user);
                await _genericRepository.Update(user);
            }
        }
    }


}
