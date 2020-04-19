using StudyB.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Models
{
    [UsernameMustBeDifferentAttribute]
    public class UserForCreationDto
    {
        //[Required]
        //public bool Admin { get; set; }
        [Required(ErrorMessage = "Username cannot be null.")]
        [MaxLength(30, ErrorMessage = "The Username cannot have more than 30 characters.")]
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
    }
}
