using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{userId}")]
        public ActionResult GetUser(Guid userId)
        {
            var userFromRepo = this.studyRepository.GetUser(userId);
            return Ok(this.mapper.Map<UserDto>(userFromRepo));
        }

    }
}