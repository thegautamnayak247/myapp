namespace MyApplication.Dal
{
    public interface ILoginDal
    {
        bool VerifyLogin(string emailId, string password);
    }
}