// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using $safeprojectname$.Models.Messages;
using $safeprojectname$.Models.Messages.Exceptions;

namespace $safeprojectname$.Services.Foundations.Messages
{
    public partial class MessageService
    {
        private void ValidateMessage(Message message)
        {
            ValidateMessageIsNotNull(message);

            Validate((Rule: IsInvalid(message.Text), Parameter: nameof(Message.Text)));
        }

        private void ValidateMessageIsNotNull(Message message)
        {
            if (message is null)
            {
                throw new NullMessageException();
            }
        }

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidProfileException =
                new InvalidMessageException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidProfileException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidProfileException.ThrowIfContainsErrors();
        }
    }
}
