namespace KAMU.API.Infrastructure.Extensions
{
    /// <summary>
    /// Manages the extensions of an integer type
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Checks if the input is greater than the value
        /// </summary>
        /// <param name="input">Source object</param>
        /// <param name="value">paramter object</param>
        /// <returns>A boolean value</returns>
        public static bool IsGreaterThan(this int input, int value)
        {
            return input > value;
        }

        /// <summary>
        /// Checks if the input is less than the value
        /// </summary>
        /// <param name="input">Source object</param>
        /// <param name="value">paramter object</param>
        /// <returns>A boolean value</returns>
        public static bool IsLessThan(this int input, int value)
        {
            return !IsGreaterThan(input, value);
        }

        /// <summary>
        /// Checks if the input is greater than or equal to the value
        /// </summary>
        /// <param name="input">Source object</param>
        /// <param name="value">paramter object</param>
        /// <returns>A boolean value</returns>
        public static bool IsGreaterThanOrEqualTo(this int input, int value)
        {
            return input >= value;
        }

        /// <summary>
        /// Checks if the input is less than or equal to the value
        /// </summary>
        /// <param name="input">Source object</param>
        /// <param name="value">paramter object</param>
        /// <returns>A boolean value</returns>
        public static bool IsLessThanOrEqualTo(this int input, int value)
        {
            return input <= value;
        }
        
    }
}
