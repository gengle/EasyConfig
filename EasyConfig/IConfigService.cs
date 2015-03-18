namespace EasyConfig
{
    public interface IConfigService
    {
        T GetValue<T>() where T : ConfigKeyProvider, new();
    }

    

}