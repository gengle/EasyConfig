using EasyConfig;
using EasyConfig.Formatters;

namespace SampleApp.MyKeys
{
    public class NumberOfExecutions : ConfigKeyProvider<int>
    {
        public override ConfigKey<int> OnGetKey()
        {
            return NewKey<IntFormatter>()
                .UseDefaultValue(0)
                .UseDescription("Listing of executions");
        }
    }
}