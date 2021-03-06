// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Xeptions;

namespace SFcore.Library.Template.Models.Messages.Exceptions
{
    public class FailedMessageServiceException : Xeption
    {
        public FailedMessageServiceException(Exception innerException)
            : base(message: "Failed Message service occurred, please contact support", innerException)
        { }
    }
}
