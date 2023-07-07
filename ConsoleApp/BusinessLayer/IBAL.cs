using BusinessModel;

namespace BusinessLayer
{
    public interface IBAL
    {
        public void Register(User objUser);
        public bool Login(User objUser);
        public User GetData(string username);
    }
}
