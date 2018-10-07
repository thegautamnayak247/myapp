using System.Collections.Generic;
using MyApplication.Core;

namespace MyApplication.Dal
{
    public interface IUserDal
    {
        List<User> GetUsers();
        bool SaveUser(User user);
        User GetUserById(int userId);
    }
}