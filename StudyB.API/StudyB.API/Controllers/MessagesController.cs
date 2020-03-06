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
    [Route("api/messages")]
    public class MessagesController : ControllerBase
    {
        private readonly IStudyRepository studyRepository;
        private readonly IMapper mapper;

        public MessagesController(IStudyRepository studyRepository, IMapper mapper)
        {
            this.studyRepository = studyRepository 
                ?? throw new ArgumentNullException(nameof(studyRepository));
            this.mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult GetMessages()
        {
            var messages = this.studyRepository.GetMessages();

            return Ok(this.mapper.Map<IEnumerable<MessageDto>>(messages));
        }

        [HttpGet("{messageId}", Name = "GetMessage")]
        public ActionResult GetChatroomMessage(Guid messageId)
        {
            var message = this.studyRepository.GetMessages(messageId);

            return Ok(this.mapper.Map<MessageDto>(message));
        }

        [HttpPost("{chatroomId}/users/{userId}/messages")]
        public ActionResult<MessageDto> CreateChatroomMessage(Guid chatroomId, Guid userId, MessageForCreationDto message)
        {
            if (!this.studyRepository.UserExist(userId))
            {
                return NotFound();
            }

            if (!this.studyRepository.ChatroomExist(chatroomId))
            {
                return NotFound();
            }

            var messageEntity = this.mapper.Map<Message>(message);
            this.studyRepository.AddMessage(chatroomId, userId, messageEntity);
            this.studyRepository.Save();

            var messageToReturn = this.mapper.Map<MessageDto>(messageEntity);

            //fix this problem
            //return CreatedAtAction("GetMessage", new { messageId = messageEntity.Id }
            //    , messageToReturn);

            return Ok(messageToReturn);
        }
    }
}
