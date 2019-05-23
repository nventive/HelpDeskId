using System.Globalization;

namespace HelpDeskId
{
    /// <summary>
    /// Generates identifiers suitable for being easily read by a human.
    /// </summary>
    public interface IHelpDeskIdGenerator
    {
        /// <summary>
        /// Generates an identifier suitable for being easily read by a human.
        /// </summary>
        /// <param name="cultureInfo">The current <see cref="CultureInfo"/> to use for word selection. Defaults to <see cref="CultureInfo.CurrentCulture"/>.</param>
        /// <returns>The non-globally unique readable id.</returns>
        string GenerateReadableId(CultureInfo cultureInfo = null);
    }
}
