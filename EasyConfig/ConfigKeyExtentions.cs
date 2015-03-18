using System;

namespace EasyConfig
{
    public static class ConfigKeyExtentions
    {
        public static ConfigKey UseFormatter<T>(this ConfigKey key) where T: IKeyValueFormatter, new()
        {
            var formatter = new T();
            key.ValueFormatter = formatter;
            return key;
        }

        public static ConfigKey<T> UseDescription<T>(this ConfigKey<T> key, string value)
        {
            key.Description = value;
            return key;
        }

        public static ConfigKey<T> UseDefaultValue<T>(this ConfigKey<T> key, T value)
        {
            key.DefaultValue = value.ToString();
            return key;
        }

        public static ConfigKey<string> UseDefaultValue<T>(this ConfigKey<string> key, T value)
        {
            key.DefaultValue = value.ToString();
            return key;
        }

        public static ConfigKey<int> UseDefaultValue<T>(this ConfigKey<int> key, T value)
        {
            key.DefaultValue = value.ToString();
            return key;
        }

        public static ConfigKey<DateTime?> UseDefaultValue<T>(this ConfigKey<DateTime?> key, T value)
        {
            key.DefaultValue = value.ToString();
            return key;
        }
    }
}