// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Xeptions;

namespace $safeprojectname$.Models.Messages.Exceptions
{
    public class MessageServiceException : Xeption
    {
        public MessageServiceException(Exception innerException)
            : base(message: "Message service error occurred, contact support.", innerException) { }
    }
}
