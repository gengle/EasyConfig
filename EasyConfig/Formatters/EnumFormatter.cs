using System;

namespace EasyConfig.Formatters
{
    public class EnumFormatter<T> : IKeyValueFormatter where T:struct
    {
        public object ImportForeignString(string inputString)
        {
            T output;
            System.Enum.TryParse<T>(inputString, out output);
            return output;
        }

        public string ExportForeignString(object value)
        {
            return Enum.GetName(typeof (T), value);
        }
    }
}