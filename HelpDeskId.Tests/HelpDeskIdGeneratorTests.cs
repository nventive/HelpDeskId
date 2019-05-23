using System.Globalization;
using FluentAssertions;
using Moq;
using Xunit;

namespace HelpDeskId.Tests
{
    public class HelpDeskIdGeneratorTests
    {
        [Fact]
        public void ItShouldGenerateReadableIds()
        {
            var numberOfWords = 3;
            var wordsProviderMock = new Mock<IWordsProvider>();
            wordsProviderMock.Setup(x => x.GetWords(numberOfWords, CultureInfo.CurrentCulture))
                .Returns(new[] { "one", "two", "three" })
                .Verifiable();

            var helpDeskIdGenerator = new HelpDeskIdGenerator(numberOfWords: numberOfWords, wordsProvider: wordsProviderMock.Object);

            var result = helpDeskIdGenerator.GenerateReadableId();

            result.Should().Be("one-two-three");
            wordsProviderMock.Verify();
        }
    }
}
