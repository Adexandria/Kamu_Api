using System.Runtime.CompilerServices;

namespace KAMU.API.Infrastructure.Extensions
{
    /// <summary>
    /// Manages the extensions of a string type
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if the string is a valid
        /// </summary>
        /// <param name="input">Source object</param>
        /// <returns>a boolean value</returns>
        public static bool IsValidText(this string input)
        {
            return !string.IsNullOrEmpty(input) || !string.IsNullOrWhiteSpace(input);
        }
    }
}
