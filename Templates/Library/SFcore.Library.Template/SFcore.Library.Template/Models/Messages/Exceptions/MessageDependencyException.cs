// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Xeptions;

namespace SFcore.Library.Template.Models.Messages.Exceptions
{
    public class MessageDependencyException : Xeption
    {
        public MessageDependencyException(Exception innerException) :
            base(message: "Message dependency error occurred, contact support.", innerException)
        { }
    }
}
