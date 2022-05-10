using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StandardFramework.Tools.Commands
{
    internal class RootCommand : HelpCommandBase
    {
        public override void Configure(CommandLineApplication command)
        {
            command.FullName ="Standard Framework";

            // NB: Update ShouldHelp in dotnet-ef when adding new command groups 
            command.Command("exceptions", new ExceptionsCommand().Configure);

            command.VersionOption("--version", GetVersion);

            base.Configure(command);
        }

        protected override int Execute()
        {
            
            return base.Execute();
        }

        private static string GetVersion()
            => typeof(RootCommand).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!
                .InformationalVersion;
    }
}
