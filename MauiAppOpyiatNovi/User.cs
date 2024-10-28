using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MauiAppOpyiatNovi
{
    public class User
    {
        public User() { }
        public User(User user)
        {
            Id = user.Id;
            Login = user.Login;
            Password = user.Password;
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
