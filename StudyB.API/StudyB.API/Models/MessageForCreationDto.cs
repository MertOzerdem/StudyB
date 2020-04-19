using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Models
{
    public class MessageForCreationDto
    {
        [Required]
        [MaxLength(1500)]
        public string Text { get; set; }
        public string FileAddress { get; set; }
        //public DateTimeOffset DateOfPost { get; set; }
        //public Guid ChatroomId { get; set; }
        //public Guid UserId { get; set; }
    }
}
