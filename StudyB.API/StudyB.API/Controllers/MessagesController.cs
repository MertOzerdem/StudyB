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

        [HttpGet("{chatroomId}")]
        public ActionResult GetChatroomMessages(Guid chatroomId)
        {
            var messages = this.studyRepository.GetChatroomMessages(chatroomId);

            return Ok(this.mapper.Map<IEnumerable<MessageDto>>(messages));
        }
    }
}
