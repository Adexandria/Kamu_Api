namespace KAMU.API.Infrastructure.Extensions
{
    public static class IntExtensions
    {
        public static bool IsGreaterThan(this int input, int value)
        {
            return input > value;
        }

        public static bool IsLessThan(this int input, int value)
        {
            return !IsGreaterThan(input, value);
        }

        public static bool IsGreaterThanOrEqualTo(this int input, int value)
        {
            return input >= value;
        }
        public static bool IsLessThanOrEqualTo(this int input, int value)
        {
            return input <= value;
        }
        
    }
}
