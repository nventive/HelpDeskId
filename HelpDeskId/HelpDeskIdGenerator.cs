using System;
using System.Globalization;

namespace HelpDeskId
{
    /// <summary>
    /// Generates identifiers suitable for being easily read by a human.
    /// Ids are NOT gauranteed to be globally unique, so don't treat it a such. They are just random.
    /// Approach is based on raendomly selecting wors from a pre-defined dictionary.
    /// </summary>
    public class HelpDeskIdGenerator : IHelpDeskIdGenerator
    {
        private readonly int _numberOfWords;
        private readonly string _separator;
        private readonly IWordsProvider _wordsProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpDeskIdGenerator"/> class.
        /// </summary>
        /// <param name="numberOfWords">The number of words to pick. Defaults to 3.</param>
        /// <param name="separator">The word separator to use. Defaults to "-".</param>
        /// <param name="wordsProvider">The <see cref="IWordsProvider"/> to source the words. Defaults to <see cref="ResourcesWordsProvider"/>.</param>
        public HelpDeskIdGenerator(
            int numberOfWords = 3,
            string separator = "-",
            IWordsProvider wordsProvider = null)
        {
            _numberOfWords = numberOfWords;
            _separator = separator ?? throw new ArgumentNullException(nameof(separator));
            _wordsProvider = wordsProvider ?? new ResourcesWordsProvider();
        }

        /// <summary>
        /// Generates an identifier suitable for being easily read by a human.
        /// </summary>
        /// <param name="cultureInfo">The current <see cref="CultureInfo"/> to use for word selection. Defaults to <see cref="CultureInfo.CurrentCulture"/>.</param>
        /// <returns>The non-globally unique readable id.</returns>
        public string GenerateReadableId(CultureInfo cultureInfo = null)
        {
            var words = _wordsProvider.GetWords(_numberOfWords, cultureInfo ?? CultureInfo.CurrentCulture);
            return string.Join(_separator, words);
        }
    }
}
