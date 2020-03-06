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
    [Route("api/chatrooms")]
    public class ChatroomsController : ControllerBase
    {
        private readonly IStudyRepository studyRepository;
        private readonly IMapper mapper;

        public ChatroomsController(IStudyRepository studyRepository, IMapper mapper)
        {
            this.studyRepository = studyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ChatroomDto>> GetChatrooms()
        {
            var chatroomsFromRepo = this.studyRepository.GetChatrooms();
            return Ok(this.mapper.Map<IEnumerable<ChatroomDto>>(chatroomsFromRepo));
        }

        [HttpGet("{chatroomId}")]
        public ActionResult GetChatroom(Guid chatroomId)
        {
            var chatroomFromRepo = this.studyRepository.GetChatroom(chatroomId);
            //var a = this.mapper.Map<ChatroomDto>(chatroomFromRepo);
            return Ok(this.mapper.Map<ChatroomDto>(chatroomFromRepo));
        }

        [HttpGet("{chatroomId}/messages")]
        public ActionResult GetChatroomMessages(Guid chatroomId)
        {
            var messages = this.studyRepository.GetChatroomMessages(chatroomId);

            return Ok(this.mapper.Map<IEnumerable<MessageDto>>(messages));
        }

        [HttpGet("content")]
        public ActionResult GetChatroomsWithContent()
        {
            var chatroomsFromRepo = this.studyRepository.GetChatroomsWithContent();
            //var chatrooms = this.mapper.Map<IEnumerable<ChatroomsWithContentDto>>(chatroomsFromRepo);
            //var result = new List<ChatroomsWithContentDto>();
            //foreach (var chatroom in chatroomsFromRepo)
            //{
            //    result.Add(new ChatroomsWithContentDto
            //    {
            //        ChatroomName = chatroom.ChatroomName,
            //        Id = chatroom.Id,
            //        Messages = 
            //    });
            //}

            return Ok(this.mapper.Map<IEnumerable<ChatroomsWithContentDto>>(chatroomsFromRepo));
        }

        
    }
}
