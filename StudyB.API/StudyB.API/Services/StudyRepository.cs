using StudyB.API.DbContexts;
using StudyB.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyB.API.Services
{
    public class StudyRepository : IDisposable, IStudyRepository
    {
        private readonly BuddyLibraryContext context;

        public StudyRepository(BuddyLibraryContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return this.context.Users.ToList<User>();
        }

        public User GetUser(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(Id));
            }

            return this.context.Users.Where(u => u.Id == Id).FirstOrDefault();
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
