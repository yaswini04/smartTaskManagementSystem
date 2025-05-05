using System;
using System.Runtime.Serialization;

namespace smartTaskManagementSystem.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message) { }
    }
}