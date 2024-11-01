namespace Commend_Project
{
    public interface IUserRepository
    {
        public void Add(User user);
        public List<User> GetAll();
        public User Get(string username);
        
        public void Delete(string userName);
        public void Update(User user);

    }
}
