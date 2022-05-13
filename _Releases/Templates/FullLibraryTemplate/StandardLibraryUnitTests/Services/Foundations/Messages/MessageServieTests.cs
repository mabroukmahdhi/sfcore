// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------
using Moq;
using $ext_safeprojectname$.Brokers.DateTimes;
using $ext_safeprojectname$.Brokers.Formatters;
using $ext_safeprojectname$.Models.Messages;
using $ext_safeprojectname$.Services.Foundations.Messages;
using System;
using Tynamix.ObjectFiller;

namespace $safeprojectname$.Services.Foundations.Messages
{
    public partial class MessageServieTests
    {
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly Mock<IFormatterBroker> formatterBrokerMock;
        private readonly IMessageService messageService;

        public MessageServieTests()
        {
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            this.formatterBrokerMock = new Mock<IFormatterBroker>();

            this.messageService = new MessageService(
                dateTimeBroker: this.dateTimeBrokerMock.Object,
                formatterBroker: this.formatterBrokerMock.Object);
        }

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomText() =>
         new MnemonicString().GetValue();

        private static Message CreateRandomMessage()
        {
            string randomMessage = GetRandomText();

            return new Message() { Text = randomMessage };
        }
    }
}
