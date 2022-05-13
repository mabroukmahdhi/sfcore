// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using SFcore.Library.Template.Models.Messages;
using SFcore.Library.Template.Models.Messages.Exceptions;
using System;
using Xeptions;

namespace SFcore.Library.Template.Services.Foundations.Messages
{
    public partial class MessageService
    {
        private delegate Message ReturningMessageFunction();
        private Message TryCatch(ReturningMessageFunction returningMessageFunction)
        {
            try
            {
                return returningMessageFunction();
            }
            catch (NullMessageException nullMessageException)
            {
                throw CreateAndLogValidationException(nullMessageException);
            }
            catch (InvalidMessageException invalidMessageException)
            {
                throw CreateAndLogValidationException(invalidMessageException);
            }
            catch (NotFoundMessageException notFoundMessageException)
            {
                throw CreateAndLogValidationException(notFoundMessageException);
            }
            catch (Exception serviceException)
            {
                var failedServiceMessageException =
                    new FailedMessageServiceException(serviceException);

                throw CreateAndLogServiceException(failedServiceMessageException);
            }
        }

        private MessageValidationException CreateAndLogValidationException(Xeption exception)
        {
            var messageValidationException =
                new MessageValidationException(exception);

            return messageValidationException;
        }

        private MessageDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var messageDependencyException =
                new MessageDependencyException(exception);

            return messageDependencyException;
        }

        private MessageDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var messageDependencyException =
                new MessageDependencyException(exception);

            return messageDependencyException;
        }

        private MessageDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var messageDependencyValidationException =
                new MessageDependencyValidationException(exception);

            return messageDependencyValidationException;
        }

        private MessageServiceException CreateAndLogServiceException(Xeption exception)
        {
            var messageServiceException =
                new MessageServiceException(exception);

            return messageServiceException;
        }
    }
}
