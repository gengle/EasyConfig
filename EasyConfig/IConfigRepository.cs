namespace EasyConfig
{
    public interface IConfigRepository
    {
        string GetOrCreateKey(ConfigKey key);
        void SaveChanges(ConfigKey getKey, string value);
    }
}