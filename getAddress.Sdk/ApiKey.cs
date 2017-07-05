

using System;

namespace getAddress.Sdk
{
    public class ApiKey : Key
    {

        public ApiKey(string key) : base(key)
        {

        }
    }
    public class AdminKey:Key
    {
        public AdminKey(string key):base(key)
        {
            
        }

        
    }

    public abstract class Key
    {

        public string Value { get; private set; }

        public Key(string key)
        {
            Value = key;
        }
    }
}
