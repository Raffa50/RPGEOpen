using System;

namespace RpgeOpen.Models.Exceptions
{
    public class KeyAlreadyExistException : Exception
    {
        public string Key { get; }

        public KeyAlreadyExistException(string message, string key)
            :base(message)
        {
            Key = key;
        }
    }
}