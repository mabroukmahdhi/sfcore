// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------
using Moq;
using SFcore.Library.Template.Brokers.DateTimes;
using SFcore.Library.Template.Brokers.Formatters;
using SFcore.Library.Template.Models.Messages;
using SFcore.Library.Template.Services.Foundations.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace SFcore.Library.Template.Tests.Unit.Services.Foundations.Messages
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

        private static string GetRandomMessage() =>
         new MnemonicString().GetValue();

        private static Message CreateRandomMethodInfo()
        {
            string randomMessage = GetRandomMessage();

            return new Message() { Text = randomMessage };
        }
    }
}
