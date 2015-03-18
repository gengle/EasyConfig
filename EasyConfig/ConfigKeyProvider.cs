using EasyConfig.Formatters;

namespace EasyConfig
{
    public abstract class ConfigKeyProvider
    {
        public abstract ConfigKey GetKey();
        
        public object Value { get; set; }

        public ConfigKeyProvider ChangeValue(object value)
        {
            this.Value = value;
            return this;
        }

        public string Serialize(IKeyValueFormatter serializer, object value)
        {
            serializer = serializer ?? new StandardStringFormatter();
            return serializer.ExportForeignString(value);
        }

        public void FormatValue(IKeyValueFormatter formatter, string value)
        {
            formatter = formatter ?? new StandardStringFormatter();
            Value = formatter.ImportForeignString(value);
        }

        public sealed override string ToString()
        {
            if (Value != null)
                return Value.ToString();
            return string.Empty;
        }
    }

    public abstract class ConfigKeyProvider<T>: ConfigKeyProvider
    {
        public sealed override ConfigKey GetKey()
        {
            return OnGetKey();
        }

        public abstract ConfigKey<T> OnGetKey();

        public new ConfigKeyProvider<T> ChangeValue(T value)
        {
            base.ChangeValue(value);
            return this;
        }

        public ConfigKey<T> NewKey<TFormatter>() where TFormatter: IKeyValueFormatter, new()
        {
            var key= new ConfigKey<T>(this.GetType().Name);
            key.UseFormatter<TFormatter>();
            return key;
        }

        public new T Value
        {
            get { return (T) base.Value; }
            set { base.Value = value; }
        }


    }
}