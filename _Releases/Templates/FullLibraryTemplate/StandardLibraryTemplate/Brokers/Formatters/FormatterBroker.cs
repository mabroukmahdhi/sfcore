// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

namespace $safeprojectname$.Brokers.Formatters
{
    public class FormatterBroker : IFormatterBroker
    {
        public string Format(string message, params object[] args)
            => string.Format(message, args);
    }
}
