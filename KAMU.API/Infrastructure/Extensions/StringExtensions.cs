using System.Runtime.CompilerServices;

namespace KAMU.API.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidString(this string input)
        {
            return string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input);
        }
    }
}
