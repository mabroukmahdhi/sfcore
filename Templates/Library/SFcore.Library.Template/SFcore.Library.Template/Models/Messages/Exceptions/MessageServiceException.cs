// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Xeptions;

namespace SFcore.Library.Template.Models.Messages.Exceptions
{
    public class MessageServiceException : Xeption
    {
        public MessageServiceException(Exception innerException)
            : base(message: "Message service error occurred, contact support.", innerException) { }
    }
}
