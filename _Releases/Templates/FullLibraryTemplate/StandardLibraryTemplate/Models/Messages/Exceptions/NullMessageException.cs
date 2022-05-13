// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using Xeptions;

namespace $safeprojectname$.Models.Messages.Exceptions
{
    public class NullMessageException : Xeption
    {
        public NullMessageException()
            : base(message: "Message is null.")
        { }
    }
}
