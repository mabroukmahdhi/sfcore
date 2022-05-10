using Microsoft.Extensions.CommandLineUtils;
using StandardFramework.Tools.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardFramework.Tools
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            if (Console.IsOutputRedirected)
            {
                Console.OutputEncoding = Encoding.UTF8;
            }

            var app = new CommandLineApplication { Name = "sf" };

            new RootCommand().Configure(app);

            try
            {
                return app.Execute(args);
            }
            catch (Exception ex)
            {
                

                return 1;
            }
        }
    }
    internal class WrappedException : Exception
    {
        private readonly string _stackTrace;

        public WrappedException(string type, string message, string stackTrace)
            : base(message)
        {
            Type = type;
            _stackTrace = stackTrace;
        }

        public string Type { get; }

        public override string ToString()
            => _stackTrace;
    }
}
