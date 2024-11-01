using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Commend_Project
{
    public class UserDapperRepository : IUserRepository
    {
        public void Add(User user)
        {

            using (IDbConnection db = new SqlConnection(Counfiguration.ConnctionString))
            {
                db.Execute(UserQueries.Create, new { user.UserName, user.Password, user.Status });
            }
        }

        public void Delete(string userName)
        {
            using (IDbConnection db = new SqlConnection(Counfiguration.ConnctionString))
                db.Execute(UserQueries.Delete, new { UserName = userName });


        }

        public User Get(string username)
        {
            using (IDbConnection db = new SqlConnection(Counfiguration.ConnctionString))
            {
                return db.QueryFirstOrDefault<User>(UserQueries.GetByUserName, new { UserName = username });
               
            }
           
        }

        public List<User> GetAll()
        {
            using (IDbConnection db = new SqlConnection(Counfiguration.ConnctionString))
            {
                return db.Query<User>(UserQueries.GetAll).ToList();
            }
        }

       

        public void Update(User user)
        {

            using (IDbConnection db = new SqlConnection(Counfiguration.ConnctionString))
                db.Execute(UserQueries.Update, new { UserName =user.UserName, Password =user.Password, Status = user.Status });
        }
    }
}
