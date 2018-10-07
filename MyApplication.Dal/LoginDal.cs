using System;
using System.Linq;

namespace MyApplication.Dal
{
    public class LoginDal : ILoginDal
    {
        public bool VerifyLogin(string emailId, string password)
        {
            return UserDal.users.Any(u => String.Equals(u.Email, emailId) && String.Equals(u.Password, password));
        }
    }
}
