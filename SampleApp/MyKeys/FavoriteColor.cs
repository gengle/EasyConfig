using EasyConfig;
using EasyConfig.Formatters;

namespace SampleApp.MyKeys
{
    public class FavoriteColor : ConfigKeyProvider<string>
    {
        public override ConfigKey<string> OnGetKey()
        {
            return NewKey<StandardStringFormatter>()
                .UseDefaultValue("Blue")
                .UseDescription("Favorite Color");
        }
    }
}