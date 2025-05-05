using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smartTaskManagementSystem.Models;

namespace smartTaskManagementSystem.Models
{
    public class Admin : User
        {
            public Admin(string username) : base(username, "Admin") { }

            public override void DisplayMenu()
            {
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Create Task");
                Console.WriteLine("2. Assign Task");
                Console.WriteLine("3. View/Modify/Delete Tasks");
                Console.WriteLine("4. Filter Tasks");
                Console.WriteLine("5. Export Tasks");
            }
        }

}
