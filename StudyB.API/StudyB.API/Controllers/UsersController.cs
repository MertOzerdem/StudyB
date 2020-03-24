using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudyB.API.Entities;
using StudyB.API.Models;
using StudyB.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IStudyRepository studyRepository;
        private readonly IMapper mapper;

        public UsersController(IStudyRepository studyRepository, IMapper mapper)
        {
            this.studyRepository = studyRepository 
                ?? throw new ArgumentNullException(nameof(studyRepository));
            this.mapper = mapper 
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            var usersFromRepo = this.studyRepository.GetUsers();
            return Ok(this.mapper.Map<IEnumerable<UserDto>>(usersFromRepo));
            
        }

        [HttpGet("{userId}", Name = "GetAuthor")]
        public ActionResult GetUser(Guid userId)
        {
            var userFromRepo = this.studyRepository.GetUser(userId);
            return Ok(this.mapper.Map<UserDto>(userFromRepo));
        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser(UserForCreationDto user)
        {
            var userEntity = this.mapper.Map<User>(user);
            this.studyRepository.AddUser(userEntity);
            this.studyRepository.Save();

            var userToReturn = this.mapper.Map<UserDto>(userEntity);

            return CreatedAtRoute("GetAuthor", 
                new { userId = userToReturn.Id }, 
                userToReturn);
        }

        

    }
}