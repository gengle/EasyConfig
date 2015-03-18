namespace EasyConfig
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigRepository _configRepository;

        public ConfigService(IConfigRepository configRepository)
        {
            this._configRepository = configRepository;
        }

        public T GetValue<T>() where T : ConfigKeyProvider, new()
        {
            var provider = new T();
            var key = provider.GetKey();

            var result = _configRepository.GetOrCreateKey(key);

            provider.FormatValue(key.ValueFormatter, result);
            return provider;
        }

        public void SaveChanges<T>(T provider) where T : ConfigKeyProvider
        {
            var key = provider.GetKey();

            var formattedValue = provider.Serialize(key.ValueFormatter, provider.Value);
            _configRepository.SaveChanges(key, formattedValue);
        }
    }
}