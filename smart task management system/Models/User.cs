using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace smartTaskManagementSystem.Models
{
        public abstract class User
        {
            public string Username { get; set; }
            public string Role { get; set; }
        public object Name { get; internal set; }

        protected User(string username, string role)
            {
                Username = username;
                Role = role;
            }

            public abstract void DisplayMenu();
        }
}

