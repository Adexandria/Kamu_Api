using KAMU.API.Infrastructure.Extensions;
using System.ComponentModel.DataAnnotations;

namespace KAMU.API.Infrastructure.Utilities
{
    /// <summary>
    /// Validates request properties
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// validation constructor
        /// </summary>
        public Validation()
        {
            Result = ActionResponse.Successful();
           
        }

        /// <summary>
        /// checks that a condition is met and returns appropriate response
        /// </summary>
        /// <param name="condition">condition to check</param>
        /// <param name="error">an error message for failure</param>
        /// <returns>the validation result</returns>
        public Validation Is(bool condition, string error)
        {
            Validate(condition, error);
            return this;
        }

        /// <summary>
        /// validates a string
        /// </summary>
        /// <param name="text">the string to validate</param>
        /// <param name="error">an error message for failure</param>
        /// <returns>the validation result</returns>
        public Validation IsValidText(string text, string error)
        {
            Validate(text.IsValidText(), error);
            return this;
        }

        /// <summary>
        /// validates an email string
        /// </summary>
        /// <param name="email">the email string to validate</param>
        /// <param name="error">an error message for failure</param>
        /// <returns>the validation result</returns>
        public Validation IsValidEmail(string email, string error)
        {
            var condition = new EmailAddressAttribute().IsValid(email);
            Validate(condition, error);
            return this;
        }

        /// <summary>
        /// validates a guid
        /// </summary>
        /// <param name="id">the guid to validate</param>
        /// <param name="error">an error message for failure</param>
        /// <returns>the validation result</returns>
        public Validation IsValidGuid(Guid id, string error)
        {
            Validate(id != Guid.Empty, error);
            return this;
        }

        /// <summary>
        /// checks if an input int is greater than a value
        /// </summary>
        /// <param name="input">integer input</param>
        /// <param name="value">int value to check against</param>
        /// <param name="error">an error message for failure</param>
        /// <returns>the validation result</returns>
        public Validation IsGreaterThan(int input, int value, string error)
        {
            Validate(input.IsGreaterThan(value), error);
            return this;
        }

        /// <summary>
        /// checks if an input int is less than a value
        /// </summary>
        /// <param name="input">integer input</param>
        /// <param name="value">int value to check against</param>
        /// <param name="error">an error message for failure</param>
        /// <returns></returns>
        public Validation IsLessThan(int input, int value, string error)
        {
            Validate(input.IsLessThan(value), error);
            return this;
        }

        /// <summary>
        /// checks if an input int is greater than or equal to a value
        /// </summary>
        /// <param name="input">integer input</param>
        /// <param name="value">int value to check against</param>
        /// <param name="error">an error message for failure</param>
        /// <returns>the validation result</returns>
        public Validation IsGreaterThanOrEqualTo(int input, int value, string error)
        {
            Validate(input.IsGreaterThanOrEqualTo(value), error);
            return this;
        }

        /// <summary>
        /// checks if an input int is less than or equal to a value
        /// </summary>
        /// <param name="input">integer input</param>
        /// <param name="value">int value to check against</param>
        /// <param name="error">an error message for failure</param>
        /// <returns>the validation result</returns>
        public Validation IsLessThanOrEqualTo(int input, int value, string error)
        {
            Validate(input.IsLessThanOrEqualTo(value), error);
            return this;
        }

        /// <summary>
        /// modifies response error list based on the success or failure of a condition
        /// </summary>
        /// <param name="passValidation">condition to check</param>
        /// <param name="error">an error message for failure</param>
        private void Validate(bool passValidation, string error)
        {
            if(!passValidation && Result.IsSuccessful)
            {
                Result = ActionResponse.Failed(error,StatusCodes.Status400BadRequest);
            }
            else if (!passValidation && Result.NotSuccessful)
            {
                Result.AddError(error);
            }

        }
        /// <summary>
        /// The response result from a validation
        /// </summary>
        public ActionResponse Result;
    }
}
