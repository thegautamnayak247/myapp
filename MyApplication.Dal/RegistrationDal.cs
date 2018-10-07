using MyApplication.Core;
using System.Collections.Generic;
using System.Linq;

namespace MyApplication.Dal
{
    public class RegistrationDal : IRegistrationDal
    {
        static List<User> users = new List<User>()
            {
                new User(){UserId=1,Age=25,FirstName="Ramya", LastName="Pinnaka", Gender="Female", ContactNumber="+91-1234578", Email="ramya.pinnaka@gmail.com", Password="Test123"},
                new User(){UserId=2,Age=35,FirstName="Alex", LastName="Hales", Gender="Male" ,ContactNumber="+91-1234578", Email="alex.hales@gmail.com", Password="Test345"},
                new User(){UserId=3,Age=45,FirstName="Kevin", LastName="Dockx", Gender="Male",ContactNumber="+91-1234578", Email="kevin.dockx@gmail.com", Password="Test343"}
            };

        public User GetUserById(int userId)
        {
            return users.Where(user => user.UserId == userId).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return users;
        }
        public bool SaveUser(User user)
        {
            users.Add(user);
            return true;
        }
    }
}
