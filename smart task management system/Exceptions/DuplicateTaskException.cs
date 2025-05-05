using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartTaskManagementSystem.Exceptions
{
    public class DuplicateTaskException : Exception
    {
        public DuplicateTaskException(string message) : base(message) { }
    }

}
