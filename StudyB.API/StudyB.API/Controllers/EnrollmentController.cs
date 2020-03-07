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
    [Route("api/enroll")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IStudyRepository studyRepository;
        private readonly IMapper mapper;

        public EnrollmentController(IStudyRepository studyRepository, IMapper mapper)
        {
            this.studyRepository = studyRepository;
            this.mapper = mapper;
        }

        [HttpPost("{chatroomId}/enrollChatroom/{userId}")]
        public ActionResult<ChatroomDto> EnrollChatroom(Guid chatroomId, Guid userId)
        {

            if (!this.studyRepository.UserExist(userId))
            {
                return NotFound();
            }

            if (!this.studyRepository.ChatroomExist(chatroomId))
            {
                return NotFound();
            }

            var returnValue = this.studyRepository.AddUserChatroom(chatroomId, userId);
            this.studyRepository.Save();

            if (returnValue == true)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
