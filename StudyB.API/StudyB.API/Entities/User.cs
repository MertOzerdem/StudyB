using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public bool Admin { get; set; }
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        public ICollection<Message> Messages { get; set; }
            = new List<Message>();
        public ICollection<UserChatroom> UserChatrooms { get; set; }
            = new List<UserChatroom>();
        public ICollection<UserReward> UserRewards { get; set; } 
            = new List<UserReward>();  
    }
}