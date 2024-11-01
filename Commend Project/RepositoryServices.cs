using Colors.Net.StringColorExtensions;
using Colors.Net;
using Commend_Project;
namespace Commend_Project.UserService;
public class UserService 

{
   UserDapperRepository _userDapperRepository = new UserDapperRepository();
    private User _currentUser;
    public void GetUser()
    {
        
      var x =  _userDapperRepository.Get("a");
    }
    public void Register(string username, string password)
    {
       
        {
            bool isSpecial = password.Any(s => (s >= 33 && s <= 47) || s == 64);

            if (password.Length < 5 || !isSpecial)
            {
                ColoredConsole.WriteLine("Password > 5 Char And One Special Character".DarkRed());
                return;
            }
            var user = _userDapperRepository.Get(username);
            if (user != null)
            {
                ColoredConsole.WriteLine("Filed UserName Already Exist".DarkRed());
                return;
            }
            var newUser = new User
            {
                Id = _userDapperRepository.GetAll().Count + 1,
                UserName = username,
                Password = password,
                Status = "Available"
            };
            _userDapperRepository.Add(newUser);
            ColoredConsole.WriteLine("Register Successful".DarkGreen());
        }

        //catch (Exception ex)
        //{
        //    ColoredConsole.WriteLine($"Error Register:{ex.Message}".DarkRed());

        //}
    }
    public void Login(string userName, string password)
    {
        try
        {
            var user = _userDapperRepository.Get(userName);
            if (user == null)
            {
                ColoredConsole.WriteLine("Not UserName Found".DarkRed());
                return;
            }
            if (user.Password != password)
            {
                ColoredConsole.WriteLine("Wrong Password".DarkRed());
                return;
            }
            if (_currentUser != null)
            {
                ColoredConsole.WriteLine("Wrong Your Login".DarkRed());
                return;
            }

            _currentUser = user;
            ColoredConsole.WriteLine($" ****   Welcome {userName}   ****".DarkGreen());


        }

        catch (Exception ex)
        {
            ColoredConsole.WriteLine($"Error Login: {ex.Message}".DarkRed());
        }

    }


    public void ChngeStatus(string status)
    {
        if (_currentUser == null)
        {
            ColoredConsole.WriteLine("Wrong|First Login".DarkRed());
            return;
        }
        if (status != "available" && status != "notavailable")
        {
            ColoredConsole.WriteLine("Invalid Status|Use 'available' Or 'notavailable'".DarkRed());
            return;
        }
        _currentUser.Status = status;
        _userDapperRepository.Update(_currentUser);
        ColoredConsole.WriteLine($"Status Change To {status}".DarkGreen());

    }

    public void Search(string userName)
    {
        if (_currentUser == null)
        {
            ColoredConsole.WriteLine("Wrong|First Login".DarkRed());
            return;
        }
        var users = _userDapperRepository.GetAll().Where(x => x.UserName.Contains(userName)).ToList();
        if (users.Count == 0)
        {
            ColoredConsole.WriteLine("Not User Found".DarkRed());
            return;
        }
        foreach (var user in users)
        {
            ColoredConsole.WriteLine($"Id: {user.Id} / UserName:{user.UserName} /Status:{user.Status}".DarkYellow());
        }
    }
    public void ChangePassword(string Old, string New)
    {
        if (_currentUser == null)
        {
            ColoredConsole.WriteLine("Wrong|First Login".DarkRed());
            return;
        }
        bool isSpecial = New.Any(s => (s >= 33 && s <= 47) || s == 64);
        if (New.Length <= 5 || !isSpecial)
        {
            ColoredConsole.WriteLine("Wrong |Password > 5 Char And One Special Character".DarkRed());
            return;
        }
        if (_currentUser.Password != Old)
        {
            ColoredConsole.WriteLine("Old Password Is Incorrect".DarkRed());
            return;
        }
        _currentUser.Password = New;

        _userDapperRepository.Update(_currentUser);
        ColoredConsole.WriteLine("Password Change Successful".DarkGreen());
    }
    public void Logout()
    {
        if (_currentUser == null)
        {
            ColoredConsole.WriteLine("You Are Not Login".DarkRed());
            return;
        }

        _currentUser = null;
        ColoredConsole.WriteLine("You Logout Successfull".DarkGreen());
    }
}