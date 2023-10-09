using System.Runtime.CompilerServices;

namespace KAMU.API.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidText(this string input)
        {
            return !string.IsNullOrEmpty(input) || !string.IsNullOrWhiteSpace(input);
        }
    }
}
