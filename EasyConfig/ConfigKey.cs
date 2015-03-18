namespace EasyConfig
{
    public class ConfigKey
    {
        public string KeyName { get; set; }
        public string DefaultValue {get;set;}
        public string Description { get; set; }
        public IKeyValueFormatter ValueFormatter { get; set; }

        public ConfigKey(string keyName)
        {
            KeyName = keyName;
        }
    }

    public class ConfigKey<T> : ConfigKey
    {
        public ConfigKey(string keyName)
            : base(keyName)
        {
        }
    }
}