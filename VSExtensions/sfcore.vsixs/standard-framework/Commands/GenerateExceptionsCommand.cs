using StandardFramework.Tools.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StandardFramework.Tools.Commands
{
    internal partial class GenerateExceptionsCommand
    {

        protected override void Validate()
        {
            base.Validate();

            if (string.IsNullOrWhiteSpace(_model.Value))
            {
                throw new CommandException(string.Format(Resources.MissingArgument, _model.Name));
            }
        }

        protected override int Execute()
        {
            var AssemblyFileName = Path.GetFileNameWithoutExtension(Assembly!.Value()!);
            var StartupAssemblyFileName = StartupAssembly == null
                  ? AssemblyFileName
                  : Path.GetFileNameWithoutExtension(StartupAssembly!.Value()!);

            var AppBasePath = Path.GetFullPath(
                 Path.Combine(Directory.GetCurrentDirectory(), Path.GetDirectoryName(StartupAssembly.Value() ?? Assembly!.Value())!));

            var RootNamespace = AssemblyFileName;
            var ProjectDirectory = Directory.GetCurrentDirectory();

            string moldelsFolder = Path.Combine(Path.GetDirectoryName(ProjectDirectory), "Models");
            string myModelFolder = Path.Combine(moldelsFolder, _model.Value + "s");
            string myModelExceptionsFolder = Path.Combine(myModelFolder, "Exceptions");

            CreateFolder(moldelsFolder);
            CreateFolder(myModelFolder);
            CreateFolder(myModelExceptionsFolder);

            CreateExceptionFile(myModelExceptionsFolder, template: ".\\Design\\Templates\\ModelExceptions\\Exc1.txt", $"Failed{_model.Value}ServiceException", RootNamespace,_model.Value);
            CreateExceptionFile(myModelExceptionsFolder, template: ".\\Design\\Templates\\ModelExceptions\\Exc2.txt", $"Invalid{_model.Value}Exception", RootNamespace,_model.Value);
            CreateExceptionFile(myModelExceptionsFolder, template: ".\\Design\\Templates\\ModelExceptions\\Exc3.txt", $"{_model.Value}DependencyException", RootNamespace,_model.Value);


            return base.Execute();
        }

        private void CreateExceptionFile(
            string myModelExceptionsFolder,
            string template,
            string csName, 
            string projName,
            string model)
        {
            string expTxt = File.ReadAllText(template)
                                .Replace("#Model#", model)
                                .Replace("#namespace#", $"{projName}.Models.{model}s.Exceptions");
            File.WriteAllText(Path.Combine(myModelExceptionsFolder, $"{csName}.cs"), expTxt);

        }

        private void CreateFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }
    }
}
