// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using Xeptions;

namespace $safeprojectname$.Models.Messages.Exceptions
{
    public class InvalidMessageException : Xeption
    {
        public InvalidMessageException()
            : base(message: "Invalid Message. Please correct the errors and try again.")
        { }
    }
}
