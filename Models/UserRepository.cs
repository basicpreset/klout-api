using System;
namespace KloutAPI.Models
{
    public class UserRepository : IUserRepository
    {
        private AppDBContext _context;

        public UserRepository(AppDBContext dbContext)
        {
            _context = dbContext;
        }

        public void EditUser(int Id)
        {
            throw new NotImplementedException();
        }

        public User Get(int Id)
        {
            return _context.users.Find(Id);
        }
    }
}
