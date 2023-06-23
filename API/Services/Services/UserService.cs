using AutoMapper;
using Models.DTO;
using Models.Models;
using Services.IServices;
using Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly Marber_BBDDContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(Marber_BBDDContext _context)
        {
            _dbContext = _context;
            _mapper = AutoMapperConfig.Configure();
        }

        public List<UserDTO> GetUsers()
        {
            return _mapper.Map<List<UserDTO>>(_dbContext.Users.ToList());
        }

    }
}
