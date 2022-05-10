using Microsoft.Extensions.CommandLineUtils;
using StandardFramework.Tools.Properties;

namespace StandardFramework.Tools.Commands
{
    internal class ExceptionsCommand : HelpCommandBase
    {
        public override void Configure(CommandLineApplication command)
        {
            command.Description = Resources.GenerateExceptionsDescription;

            command.Command("generate", new GenerateExceptionsCommand().Configure); 

            base.Configure(command);
        }
    }
}