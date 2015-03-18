using System;
using EasyConfig;
using EasyConfig.Formatters;

namespace SampleApp.MyKeys
{
    public class LastExecutionDate : ConfigKeyProvider<DateTime?>
    {
        public override ConfigKey<DateTime?> OnGetKey()
        {
            return NewKey<NullableDateFormatter>()
                 .UseDefaultValue(null)
                 .UseDescription("Last Execution Date");
        }
    }
}