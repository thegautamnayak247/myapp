using System.Collections.Generic;
using MyApplication.Core;

namespace MyApplication.Dal
{
    public interface IRegistrationDal
    {
        List<User> GetUsers();
        bool SaveUser(User user);
        User GetUserById(int userId);
    }
}