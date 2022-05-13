// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using SFcore.Library.Template.Models.Messages;

namespace SFcore.Library.Template.Services.Foundations.Messages
{
    public interface IMessageService
    {
        Message Standardize(Message message);
    }
}
