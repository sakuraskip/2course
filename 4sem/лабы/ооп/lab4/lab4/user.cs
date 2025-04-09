using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
  public  class User
    {
        public string Role {  get; set; }
        public string username { get; set; }
        public string  password { private get; set; }

        public User(string username,string password)
        {
            if(username == "admin" && password == "admin")
            {
                this.Role = "admin";
                this.username = "admin";
                this.password = "admin";
            }
            else
            {
                this.Role = "user";
                this.username = username;
                this.password = password;
            }
        }
    }
}
