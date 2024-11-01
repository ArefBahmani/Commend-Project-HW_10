using Colors.Net.StringColorExtensions;
using Colors.Net;
using Commend_Project.UserService;


UserService _userService = new UserService();
//_userService.GetUser();
while (true)
{
    try
    {
        Console.Clear();
        ColoredConsole.Write("Enter Command : ".DarkYellow());
        string[] commands = Console.ReadLine().Split(' ');
        if (commands.Length == 0)
        {
            ColoredConsole.Write("Invalid Command".DarkRed());
            Console.ReadKey();
            continue;
        }
        string command = commands[0].ToLower();
        switch (command)
        {
            case "register":
                if (commands.Length == 5 && commands[1].ToLower() == "--username" && commands[3].ToLower() == "--password")
                {
                    string username = commands[2].ToLower();
                    string password = commands[4].ToLower();
                    _userService.Register(username, password);
                    Console.ReadKey();
                }
                else
                {
                    ColoredConsole.Write("Invalid Format / Format=> Register --username <username> --password <password>".DarkRed());
                    Console.ReadKey();
                }
                break;

            case "login":
                if (commands.Length == 5 && commands[1].ToLower() == "--username" && commands[3].ToLower() == "--password")
                {
                    string username = commands[2].ToLower();
                    string password = commands[4].ToLower();
                    _userService.Login(username, password);
                    Console.ReadKey();
                }
                else
                {
                    ColoredConsole.Write("Invalid Format / Format=> Login --username <username> --password <password>".DarkRed());
                    Console.ReadKey();
                }
                break;

            case "change":
                if (commands.Length == 3 && commands[1].ToLower() == "--status")
                {
                    string status = commands[2].ToLower();
                    _userService.ChngeStatus(status);
                    Console.ReadKey();
                }
                else
                {
                    ColoredConsole.Write("Invalid Format / Format change --status <newStatus>".DarkRed());
                    Console.ReadKey();
                }
                break;

            case "search":
                if (commands.Length == 3 && commands[1] == "--username")
                {
                    string username = commands[2].ToLower();
                    _userService.Search(username);
                    Console.ReadKey();
                }
                else
                {
                    ColoredConsole.Write("Invalid Format / Format search --username <username>".DarkRed());
                    Console.ReadKey();
                }
                break;

            case "changepassword":
                if (commands.Length == 5 && commands[1] == "--old" && commands[3] == "--new")
                {
                    string old = commands[2];
                    string New = commands[4];
                    _userService.ChangePassword(old, New);
                    Console.ReadKey();
                }
                else
                {
                    ColoredConsole.Write("Invalid Format / Format changepassword --old <oldPassword> --new <newPassword>".DarkRed());
                    Console.ReadKey();
                }
                break;

            case "logout":
                _userService.Logout();
                Console.ReadKey();
                break;

            case "--help":

                ColoredConsole.WriteLine(" Register --username <username> --password <password>".DarkGray());
                ColoredConsole.WriteLine(" Login --username <username> --password <password>".DarkGray());
                ColoredConsole.WriteLine(" change --status <newStatus>".DarkGray());
                ColoredConsole.WriteLine(" search --username <username>".DarkGray());
                ColoredConsole.WriteLine(" changepassword --old <oldPassword> --new <newPassword>".DarkGray());
                Console.ReadKey();
                break;


            default:
                ColoredConsole.WriteLine("Unknown Command".DarkRed());
                Console.ReadKey();
                break;


        }
    }

    catch (Exception ex)
    {
        ColoredConsole.WriteLine($"Unexpected Error: {ex.Message}".DarkRed());
        Console.ReadKey();
    }
}