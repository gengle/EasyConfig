using System;

namespace EasyConfig.RaptorDbStorage.Infrastructure
{
    public class KeyValueDoc
    {
        public Guid Id { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }

        public KeyValueDoc(ConfigKey key, string value)
        {
            this.KeyName = key.KeyName;
            this.KeyValue = value ?? key.DefaultValue;
            this.Id = GuidUtility.Create(GuidUtility.UrlNamespace, key.KeyName);
        }
    }
}