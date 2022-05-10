using Microsoft.Extensions.CommandLineUtils;
using StandardFramework.Tools.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardFramework.Tools.Commands
{
    internal partial class GenerateExceptionsCommand : ProjectCommandBase
    {
        private CommandArgument? _model;
        private CommandOption? _outputDir;
        private CommandOption? _namespace;

        public override void Configure(CommandLineApplication command)
        {
            command.Description = Resources.GenerateExceptionsDescription;

            _model = command.Argument("<MODEL>", Resources.ModelNameDescription);

            _outputDir = command.Option("-o|--output-dir <PATH>",
                                        Resources.ExceptionsOutputDirDescription);

            _namespace = command.Option("-n|--namespace <NAMESPACE>",
                                          Resources.ExceptionsNamespaceDescription);

            base.Configure(command);
        }
    }
}
