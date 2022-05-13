// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Xeptions;

namespace $safeprojectname$.Models.Messages.Exceptions
{
    public class AlreadyExistsMessageException : Xeption
    {
        public AlreadyExistsMessageException(Exception innerException)
            : base(message: "Message with the same id already exists.", innerException)
        { }
    }
}
