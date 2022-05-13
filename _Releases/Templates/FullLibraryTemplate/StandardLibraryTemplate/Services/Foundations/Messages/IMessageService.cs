// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using $safeprojectname$.Models.Messages;

namespace $safeprojectname$.Services.Foundations.Messages
{
    public interface IMessageService
    {
        Message Standardize(Message message);
    }
}
