// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------
using $safeprojectname$.Brokers.DateTimes;
using $safeprojectname$.Brokers.Formatters;
using $safeprojectname$.Models.Messages;
using System;

namespace $safeprojectname$.Services.Foundations.Messages
{
    public partial class MessageService : IMessageService
    {
        private readonly IDateTimeBroker dateTimeBroker;
        private readonly IFormatterBroker formatterBroker;

        public MessageService(
            IDateTimeBroker dateTimeBroker,
            IFormatterBroker formatterBroker)
        {
            this.dateTimeBroker = dateTimeBroker;
            this.formatterBroker = formatterBroker;
        }

        public Message Standardize(Message message)
            => TryCatch(() =>
            {
                ValidateMessage(message);

                DateTimeOffset dateTime = this.dateTimeBroker.GetCurrentDateTimeOffset();

                string standardMessage = $"{0} => {1}";

                message.Text = this.formatterBroker.Format(standardMessage, dateTime, message.Text);

                return message;
            });
    }
}
