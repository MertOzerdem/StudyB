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

        [HttpGet("{userId}/user")]
        public ActionResult GetEnrolledChatrooms(Guid userId)
        {
            var chatroomFromRepo = this.studyRepository.GetChatromsWithUserId(userId);
            return Ok(this.mapper.Map<IEnumerable<ChatroomDto>>(chatroomFromRepo));
        }

        [HttpGet("{chatroomId}", Name ="GetChatroom")]
        public ActionResult GetChatroom(Guid chatroomId)
        {
            var chatroomFromRepo = this.studyRepository.GetChatroom(chatroomId);
            //var a = this.mapper.Map<ChatroomDto>(chatroomFromRepo);
            return Ok(this.mapper.Map<ChatroomDto>(chatroomFromRepo));
        }

        [HttpGet("{chatroomId}/messages")]
        public ActionResult GetChatroomMessages(Guid chatroomId)
        {
            var messagesFromRepo = this.studyRepository.GetChatroomMessages(chatroomId);

            //var messages = this.mapper.Map<IEnumerable<MessageWithUserDto>>(messagesFromRepo);

            var messages = new List<MessageWithUserDto>();
            foreach(var newmessage in messagesFromRepo)
            {
                messages.Add(new MessageWithUserDto
                {
                    Id = newmessage.Id,
                    Text = newmessage.Text,
                    FileAddress = newmessage.FileAddress,
                    DateOfPost = newmessage.DateOfPost,
                    UserId = newmessage.UserId,
                    UserName = newmessage.User.UserName
                });
            }

            return Ok(messages);
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

        [HttpPost]
        public ActionResult<ChatroomDto> CreateChatroom(ChatroomForCreationDto chatroom)
        {
            var chatroomEntity = this.mapper.Map<Chatroom>(chatroom);

            // Check if chatroom name exist
            if (!this.studyRepository.IsChatroomNameValid(chatroomEntity))
            {
                return BadRequest(); // EDIT TO RETURN CAUSE OF ERROR
            }

            this.studyRepository.AddChatroom(chatroomEntity);
            this.studyRepository.Save();

            var chatroomToReturn = this.mapper.Map<ChatroomDto>(chatroomEntity);

            return CreatedAtRoute("GetChatroom", 
                new { chatroomId = chatroomToReturn.Id },
                chatroomToReturn);
        }
        
    }
}
