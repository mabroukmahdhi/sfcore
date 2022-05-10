using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardFramework.Tools
{
    internal static class CommandLineApplicationExtensions
    {
        public static CommandOption Option(this CommandLineApplication command, string template, string? description)
            => command.Option(
                template,
                description,
                template.IndexOf('<') != -1
                    ? template.EndsWith(">...", StringComparison.Ordinal)
                        ? CommandOptionType.MultipleValue
                        : CommandOptionType.SingleValue
                    : CommandOptionType.NoValue);
    }
}
