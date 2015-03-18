using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyConfig;
using EasyConfig.Formatters;

namespace SampleApp.MyKeys
{
    public class SomeEnumValue : ConfigKeyProvider<SampleEnum>
    {
        public override ConfigKey<SampleEnum> OnGetKey()
        {
            return NewKey<EnumFormatter<SampleEnum>>()
                .UseDefaultValue(SampleEnum.One)
                .UseDescription("Test one two three 4");
        }
    }
}
