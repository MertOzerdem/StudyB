using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Models
{
    public class ChatroomForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public String ChatroomName { get; set; }
    }
}
