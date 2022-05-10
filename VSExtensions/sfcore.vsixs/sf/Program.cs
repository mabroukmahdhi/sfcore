using Microsoft.Extensions.CommandLineUtils;
using StandardFramework.Tools.Commands;
using System;
using System.Text;

namespace sf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (Console.IsOutputRedirected)
            {
                Console.OutputEncoding = Encoding.UTF8;
            }

            var app = new CommandLineApplication { Name = "sf" };

            new RootCommand().Configure(app);

            try
            {
                app.Execute(args);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
        }
    }
}
