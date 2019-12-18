using System;
using System.Linq;
using NSpec;
using NSpec.Domain; // SpecFinder
using NSpec.Domain.Formatters; // ConsoleFormatter

namespace NSpecSample
{
    class Program 
    {
        static void Main(string[] args)
        {
            var types = typeof(Program).Assembly.GetTypes();
            var finder = new SpecFinder(types, "");
            var tagsString = string.Join(' ', args ?? new string[0]);
            var tagsFilter = new Tags().Parse(tagsString);
            var builder = new ContextBuilder(finder, tagsFilter, new DefaultConventions());
            var runner = new ContextRunner(tagsFilter, new ConsoleFormatter(), false);
            var results = runner.Run(builder.Contexts().Build());
 
            if(results.Failures().Count() > 0)
            {
                Environment.Exit(1);
            }
        }
    }
}