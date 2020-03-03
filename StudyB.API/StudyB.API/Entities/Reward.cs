using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Entities
{
    public class Reward
    {
        [Key]
        public int Id { get; set; }

        // Change later do not seem like a fit here rewards should not keep users that have them
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
