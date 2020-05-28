using System;

namespace Parcial2
{
    public class AlreadyExistUserException : Exception
    {
        public AlreadyExistUserException(string message) : base(message)
        {
        }
    }
}