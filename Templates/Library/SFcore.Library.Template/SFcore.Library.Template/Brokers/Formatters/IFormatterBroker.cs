// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

namespace SFcore.Library.Template.Brokers.Formatters
{
    public interface IFormatterBroker
    {
        string Format(string message, params object[] args);
    }
}
