using Microsoft.Extensions.CommandLineUtils;
using StandardFramework.Tools.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardFramework.Tools.Commands
{
    internal abstract class ProjectCommandBase : SFCommandBase
    {
        private CommandOption? _modelsDir;
        private CommandOption? _projectDir;
        private CommandOption? _rootNamespace;

        protected CommandOption? Assembly { get; private set; }
        protected CommandOption? Project { get; private set; }
        protected CommandOption? StartupAssembly { get; private set; }
        protected CommandOption? StartupProject { get; private set; }
        protected CommandOption? WorkingDir { get; private set; }


        public override void Configure(CommandLineApplication command)
        {
            command.AllowArgumentSeparator = true;

            Assembly = command.Option("-a|--assembly <PATH>", Resources.AssemblyDescription);
            Project = command.Option("--project <PATH>", Resources.ProjectDescription);
            StartupAssembly = command.Option("-s|--startup-assembly <PATH>", Resources.StartupAssemblyDescription);
            StartupProject = command.Option("--startup-project <PATH>", Resources.StartupProjectDescription);
            _modelsDir = command.Option("--data-dir <PATH>", Resources.ModelsDirDescription);
            _projectDir = command.Option("--project-dir <PATH>", Resources.ProjectDirDescription);
            _rootNamespace = command.Option("--root-namespace <NAMESPACE>", Resources.RootNamespaceDescription);
            WorkingDir = command.Option("--working-dir <PATH>", Resources.WorkingDirDescription);

            base.Configure(command);
        }

        protected override void Validate()
        {
            base.Validate();

            if (!Assembly!.HasValue())
            {
                throw new CommandException(string.Format(Resources.MissingOption, Assembly.LongName));
            }
        }

         }
}
