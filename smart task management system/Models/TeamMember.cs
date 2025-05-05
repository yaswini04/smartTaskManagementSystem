using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartTaskManagementSystem.Models
{
    public class TeamMember : User
    {
        public TeamMember(string username) : base(username, "TeamMember") { }

        public override void DisplayMenu()
        {
            Console.WriteLine("Team Member Menu:");
            Console.WriteLine("1. View Tasks");
            Console.WriteLine("2. Update Task Status");
            Console.WriteLine("3. Export Tasks");
        }
    }

}
