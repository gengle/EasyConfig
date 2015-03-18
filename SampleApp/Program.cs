using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyConfig;
using EasyConfig.RaptorDbStorage;
using SampleApp.MyKeys;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var configService = new ConfigService(
                new RaptorDbConfigRepository("Config"));

            var lastExecutionDate = configService.GetValue<LastExecutionDate>();
            Console.WriteLine("Previous Execution: {0}", lastExecutionDate);
            configService.SaveChanges(lastExecutionDate.ChangeValue(DateTime.Now.AddDays(1)));

            var executionCount = configService.GetValue<NumberOfExecutions>();
            Console.WriteLine("Total executions thus far: {0}", executionCount);
            configService.SaveChanges(executionCount.ChangeValue(executionCount.Value+1));

            var sampleEnum = configService.GetValue<SomeEnumValue>();
            Console.WriteLine("What is the sampleEnumValue: {0}", sampleEnum);
            configService.SaveChanges(sampleEnum.ChangeValue(SampleEnum.Three));

            var favoriteColor = configService.GetValue<FavoriteColor>();
            Console.WriteLine("Your previous favorite color is: {0}", favoriteColor);
            Console.WriteLine("What is your new favorite color");
            configService.SaveChanges(favoriteColor.ChangeValue(Console.ReadLine()));
        }
    }
}
