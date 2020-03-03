using StudyB.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Services
{
    interface IStudyRepository
    {
        User GetUser(Guid Id);
        IEnumerable<User> GetUsers();
    }
}
