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
    [Route("api/rewards")]
    public class RewardsController : ControllerBase
    {
        private readonly IStudyRepository studyRepository;
        private readonly IMapper mapper;

        public RewardsController(IStudyRepository studyRepository, IMapper mapper)
        {
            this.studyRepository = studyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RewardDto>> GetRewards()
        {
            var rewardsFromRepo = this.studyRepository.GetRewards();
            return Ok(this.mapper.Map<IEnumerable<RewardDto>>(rewardsFromRepo));
        }

        [HttpGet("{rewardId}", Name = "GetReward")]
        public ActionResult GetReward(Guid rewardId)
        {
            var rewardFromRepo = this.studyRepository.GetReward(rewardId);
            return Ok(this.mapper.Map<RewardDto>(rewardFromRepo));
        }
    }
}
