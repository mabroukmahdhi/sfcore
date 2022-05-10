﻿using System;
using System.Runtime.Serialization;

namespace StandardFramework.Tools
{

    internal class CommandException : Exception
    {
        public CommandException(string message) : base(message)
        {
        }

        public CommandException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}