using System.Collections.Generic;
using System.Globalization;
using FluentAssertions;
using Xunit;

namespace HelpDeskId.Tests
{
    public class ResourcesWordsProviderTests
    {
        public static IEnumerable<object[]> ItShouldProvideWordsData =>
            new List<object[]>
            {
                new object[] { CultureInfo.InvariantCulture, 3 },
                new object[] { CultureInfo.GetCultureInfo("en"), 5 },
                new object[] { CultureInfo.GetCultureInfo("en-US"), 5 },
                new object[] { CultureInfo.GetCultureInfo("fr"), 4 },
                new object[] { CultureInfo.GetCultureInfo("fr-CA"), 4 },
            };

        [Theory]
        [MemberData(nameof(ItShouldProvideWordsData))]
        public void ItShouldProvideWords(CultureInfo cultureInfo, int numberOfWords)
        {
            var resources = new ResourcesWordsProvider();

            var result = resources.GetWords(numberOfWords, cultureInfo);

            result.Should().HaveCount(numberOfWords);
        }
    }
}
