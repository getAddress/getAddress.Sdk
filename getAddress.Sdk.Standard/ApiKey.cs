
namespace getAddress.Sdk
{
    public class ApiKey : Key
    {

        public ApiKey(string key) : base(key)
        {

        }

        public static implicit operator ApiKey(string str)  
        {
                return new ApiKey(str);
        }

    }

    public class AdminKey:Key
    {
        public AdminKey(string key):base(key)
        {
            
        }

        public static implicit operator AdminKey(string str)  
        {
                return new AdminKey(str);
        }
    }

    public abstract class Key
    {
        public string Value { get; private set; }

        public Key(string key)
        {
            Value = key;
        }

        public static implicit operator string(Key  key)
        {
                return key.Value;
        }

    }
}
