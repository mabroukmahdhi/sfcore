// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using Xeptions;

namespace SFcore.Library.Template.Models.Messages.Exceptions
{
    public class MessageDependencyValidationException : Xeption
    {
        public MessageDependencyValidationException(Xeption innerException)
            : base(message: "Message dependency validation occurred, please try again.", innerException)
        { }
    }
}
