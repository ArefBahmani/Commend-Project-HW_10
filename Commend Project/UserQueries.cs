using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commend_Project
{
    public static class UserQueries
    {

        public static string Create = "INSERT INTO dbo.[Users](Username,Password,Status) VALUES (@Username,@Password,@Status);";
        public static string GetByUserName = "SELECT * FROM dbo.[Users] WHERE UserName = @UserName";
        public static string GetAll = "SELECT * FROM Users";
        public static string Delete = "Delete dbo.[Users] WHERE UserName = @UserName";
        public static string Update = "UPDATE dbo.[Users] SET UserName = @UserName,Password = @Password , Status = @Status WHERE UserName = @UserName";

    }
}
