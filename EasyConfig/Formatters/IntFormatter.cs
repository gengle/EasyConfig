namespace EasyConfig.Formatters
{
    public class IntFormatter: IKeyValueFormatter
    {
        public object ImportForeignString(string inputString)
        {
            int result;
            int.TryParse(inputString, out result);
            return result;
        }

        public string ExportForeignString(object value)
        {
            if (value == null) return "0";
            var num = (int)value;
            return num.ToString();
        }
    }
}