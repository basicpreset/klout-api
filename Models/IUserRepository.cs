using System;
namespace KloutAPI.Models
{
    public interface IUserRepository
    {
        User Get(int Id);
        void EditUser(int Id);
    }
}
