namespace EasyConfig.Formatters
{
    public class StandardStringFormatter : IKeyValueFormatter
    {
        public object ImportForeignString(string inputString)
        {
            return inputString;
        }

        public string ExportForeignString(object value)
        {
            if (value != null)
                return value.ToString();
            return string.Empty;
        }
    }
}