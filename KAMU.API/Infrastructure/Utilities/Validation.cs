using KAMU.API.Infrastructure.Extensions;

namespace KAMU.API.Infrastructure.Utilities
{
    public class Validation
    {
        public Validation()
        {
            Result.Successful = true;
           
        }

        public Validation IsValidText(string text, string error)
        {
            Validate(text.IsValidText(), error);
            return this;
        }

        public Validation IsGreaterThan(int input, int value, string error)
        {
            Validate(input.IsGreaterThan(value), error);
            return this;
        }
        public Validation IsLessThan(int input, int value, string error)
        {
            Validate(input.IsLessThan(value), error);
            return this;
        }
        private void Validate(bool pass, string error)
        {
            if(!pass && Result.Successful)
            {
                Response.ValidationFailure(Result);
                Result.AddError(error);
            }
            else if (!pass && Result.NotSuccessful)
                Result.AddError(error);

        }
        public Response Result => new Response();
    }
}
