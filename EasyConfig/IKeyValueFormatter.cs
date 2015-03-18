namespace EasyConfig
{
    public interface IKeyValueFormatter
    {
        object ImportForeignString(string inputString);
        string ExportForeignString(object value);
    }
}