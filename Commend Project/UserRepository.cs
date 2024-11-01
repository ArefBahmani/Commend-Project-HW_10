namespace Commend_Project;
using Newtonsoft.Json;

public class UserRepository : IUserRepository
{
    private List<User> users = new List<User>();
    string _path = @"C:\Users\rayank\source\repos\Commend Projectusers.txt";
    public UserRepository()
    {
        var directory = Path.GetDirectoryName(_path);
        if (Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
    }
    public void Add(User user)
    {
        var data = File.ReadAllText(_path);
        var Users = JsonConvert.DeserializeObject<List<User>>(data);
        Users.Add(user);
        var result = JsonConvert.SerializeObject(Users);
        File.WriteAllText(_path, result);
    }
    public List<User> GetAll()
    {
        var data = File.ReadAllText(_path);
        var users = JsonConvert.DeserializeObject<List<User>>(data);
        return users;
    }

    public User Get(string username)
    {
        var data = File.ReadAllText(_path);
        var users = JsonConvert.DeserializeObject<List<User>>(data);
        return users.FirstOrDefault(x => x.UserName == username);
    }
    public void Update(User user)
    {
        var data = File.ReadAllText(_path);
        var users = JsonConvert.DeserializeObject<List<User>>(data);
        var update = users.FirstOrDefault(x => x.UserName == user.UserName);

        if (update != null)
        {
            update.Password = user.Password;
            update.Status = user.Status;
            var result = JsonConvert.SerializeObject(users);
            File.WriteAllText(_path, result);
        }
    }
    public void Delete(string userName)
    {
        var data = File.ReadAllText(_path);
        var Users = JsonConvert.DeserializeObject<List<User>>(data);
        var users = Users.FirstOrDefault(x => x.UserName == userName);
        Users.Remove(users);
        var result = JsonConvert.SerializeObject(Users);
        File.WriteAllText(_path, result);
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }
}