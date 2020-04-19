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

        [HttpGet("{userId}/rewards")]
        public ActionResult GetUserWithRewards(Guid userId)
        {
            var rewarsFromRepo = this.studyRepository.GetUsersWithRewards(userId);

            var rewards = new List<RewardDto>();
            foreach (var reward in rewarsFromRepo.UserRewards)
            {
                rewards.Add(new RewardDto
                {
                    Id = reward.Reward.Id,
                    RewardName = reward.Reward.RewardName
                });
            }

            var userWithRewards = this.mapper.Map<UserWithRewardDto>(rewarsFromRepo);
            userWithRewards.Rewards = rewards;

            return Ok(userWithRewards);
        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser(UserForCreationDto user)
        {
            var userEntity = this.mapper.Map<User>(user);

            // Check if user name exist
            if (!this.studyRepository.IsUserValid(userEntity))
            {
                return BadRequest(); // EDIT TO RETURN CAUSE OF ERROR
            }

            // Check If email exist
            if (!this.studyRepository.IsEmailValid(userEntity))
            {
                return BadRequest();
            }

            this.studyRepository.AddUser(userEntity);
            this.studyRepository.Save();

            var userToReturn = this.mapper.Map<UserDto>(userEntity);

            return CreatedAtRoute("GetAuthor", 
                new { userId = userToReturn.Id }, 
                userToReturn);
        }
    }
}