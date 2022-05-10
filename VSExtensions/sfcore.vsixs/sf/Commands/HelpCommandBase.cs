using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardFramework.Tools.Commands
{
    internal class HelpCommandBase : SFCommandBase
    {
        private CommandLineApplication? _command;

        public override void Configure(CommandLineApplication command)
        {
            _command = command;

            base.Configure(command);
        }

        protected override int Execute()
        {
            _command!.ShowHelp();

            return base.Execute();
        }
    }
}
