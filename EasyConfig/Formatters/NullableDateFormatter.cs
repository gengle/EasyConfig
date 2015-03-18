using System;
using System.Globalization;

namespace EasyConfig.Formatters
{
    public class NullableDateFormatter : IKeyValueFormatter
    {
        public object ImportForeignString(string inputString)
        {
            DateTime output;
            if (DateTime.TryParseExact(inputString, "M/d/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out output))
            {
                return output;
            }
            return null;
        }

        public string ExportForeignString(object value)
        {
            if (value == null) return null;
            var date = (DateTime)value;
            return date.ToString("M/d/yyyy");
        }
    }
}