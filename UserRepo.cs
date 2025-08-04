using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserRepo
    {
        private SMSContext db;

        public UserRepo()
        {
            db = new SMSContext();
        }

        public void Register(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public User Login(string username, string password)
        {
            return db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public bool Exists(string username)
        {
            return db.Users.Any(u => u.Username == username);
        }
    }
}
