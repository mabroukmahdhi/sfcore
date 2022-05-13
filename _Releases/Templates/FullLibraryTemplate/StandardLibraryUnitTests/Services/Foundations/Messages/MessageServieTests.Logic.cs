// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// ---------------------------------------------------------------
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using $ext_safeprojectname$.Models.Messages;
using System;
using Xunit;

namespace $safeprojectname$.Services.Foundations.Messages
{
    public partial class MessageServieTests
    {
        [Fact]
        public void ShouldStandardizeMessage()
        {
            // given
            DateTimeOffset randomDate = GetRandomDateTimeOffset();
            Message randomOriginalMessage =
                CreateRandomMessage();

            Message originalMessage =
                randomOriginalMessage.DeepClone();

            string formatingText = "{0} => {1}";
            string formattedText = $"{randomDate} => {randomOriginalMessage.Text}";
            string expectedMessage = formattedText;

            this.dateTimeBrokerMock.Setup(broker =>
                broker.GetCurrentDateTimeOffset())
                    .Returns(randomDate);

            this.formatterBrokerMock.Setup(broker =>
                broker.Format(formatingText, randomDate, randomOriginalMessage.Text))
                .Returns(formattedText);

            // when
            Message actualMessage = this.messageService.Standardize(originalMessage);

            // then
            actualMessage.Should().NotBeNull();
            actualMessage.Text.Should().Be(expectedMessage);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTimeOffset(),
                    Times.Once());

            this.formatterBrokerMock.Verify(broker =>
               broker.Format(formatingText, randomDate, randomOriginalMessage.Text),
                   Times.Once());

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.formatterBrokerMock.VerifyNoOtherCalls();
        }
    }
}
