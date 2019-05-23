using System.Collections.Generic;
using System.Globalization;

namespace HelpDeskId
{
    /// <summary>
    /// Provides words for <see cref="IHelpDeskIdGenerator"/>.
    /// </summary>
    public interface IWordsProvider
    {
        /// <summary>
        /// Get <paramref name="numberOfWords"/> words in the <paramref name="cultureInfo"/>.
        /// </summary>
        /// <param name="numberOfWords">The number of words to provide.</param>
        /// <param name="cultureInfo">The <see cref="CultureInfo"/> to use for words. If not found, will fallback to a neutral culture.</param>
        /// <returns>The words.</returns>
        IEnumerable<string> GetWords(int numberOfWords, CultureInfo cultureInfo);
    }
}
