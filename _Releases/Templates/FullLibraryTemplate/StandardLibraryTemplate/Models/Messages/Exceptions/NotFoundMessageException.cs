// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using System;
using Xeptions;

namespace $safeprojectname$.Models.Messages.Exceptions
{
    public class NotFoundMessageException : Xeption
    {
        public NotFoundMessageException(Guid commentId)
            : base(message: $"Couldn't find Message with id: {commentId}.")
        { }
    }
}
