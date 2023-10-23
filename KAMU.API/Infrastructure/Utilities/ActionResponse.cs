namespace KAMU.API.Infrastructure.Utilities
{
    /// <summary>
    /// Manages the request responses
    /// </summary>
    /// <typeparam name="T">Source type</typeparam>
    public class ActionResponse<T> : ActionResponse 
    {
        /// <summary>
        /// A constructor
        /// </summary>
        internal ActionResponse() { }

        /// <summary>
        /// Data to display
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Displays 200 response with data
        /// </summary>
        /// <param name="data">Data to display</param>
        /// <returns>Action response</returns>
        public static ActionResponse<T> SuccessfulOperation(T data)
        {
            return new ActionResponse<T>()
            {
                Data = data,
                StatusCode = 200,
                IsSuccessful = true,
                NotSuccessful = false,
                Errors = new List<string>()

            };
        }

        /// <summary>
        /// Displays 500 response with error
        /// </summary>
        /// <param name="error">Error to display</param>
        /// <returns>Action response</returns>
        public static ActionResponse<T> Failed(string error)
        {
            return new ActionResponse<T>()
            {
                StatusCode = 500,
                IsSuccessful = false,
                NotSuccessful = true,
                Errors = new List<string>()
                {
                    error
                }

            };
        }

        /// <summary>
        /// Displays 500 response
        /// </summary>
        /// <returns>Action response</returns>
        public static ActionResponse<T> Failed()
        {
            return new ActionResponse<T>()
            {
                StatusCode = 500,
                IsSuccessful = false,
                NotSuccessful = true,
                Errors = new List<string>()

            };
        }

        /// <summary>
        /// Displays 500 response
        /// </summary>
        /// <param name="error">Error to display</param>
        /// <param name="code">Status code</param>
        /// <returns>Action response</returns>
        public static ActionResponse<T> Failed(string error, int code)
        {
            return new ActionResponse<T>()
            {
                StatusCode = code,
                IsSuccessful = false,
                NotSuccessful = true,
                Errors = new List<string>()
                {
                    error
                }

            };
        }

        /// <summary>
        /// Displays 500 response
        /// </summary>
        /// <param name="code">Status code</param>
        /// <returns>Action response</returns>
        public static ActionResponse<T> Failed(int code)
        {
            return new ActionResponse<T>()
            {
                StatusCode = code,
                IsSuccessful = false,
                NotSuccessful = true,
                Errors = new List<string>()
            };
        }


        /// <summary>
        /// Displays 500 response
        /// </summary>
        /// <param name="errors">Errors to display</param>
        /// <param name="statuscode">Status code</param>
        /// <returns>Action response</returns>
        public static ActionResponse<T> Failed(List<string> errors, int statuscode)
        {
            return new ActionResponse<T>()
            {
                StatusCode = statuscode,
                IsSuccessful = false,
                NotSuccessful = true,
                Errors = errors
            };

        }
        /// <summary>
        /// Add error message to response
        /// </summary>
        /// <param name="error">Error to display</param>
        /// <returns></returns>
        public ActionResponse<T> AddError(string error)
        {
            Errors.Add(error);
            return this;
        }

        /// <summary>
        /// Add error messages to response
        /// </summary>
        /// <param name="errors">Errors to display</param>
        /// <returns>Action response</returns>
        public ActionResponse<T> AddErrors(List<string> errors)
        {
            if (errors == null)
                return this;
            Errors.AddRange(errors);
            return this;
        }
    }

    /// <summary>
    /// Manages request responses
    /// </summary>
    /// <typeparam name="T">Source type</typeparam>
    public class ActionTokenResponse<T> : ActionResponse<T>
    {
        /// <summary>
        /// Access Token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Display 200 response
        /// </summary>
        /// <param name="data">Source object</param>
        /// <param name="accessToken">Access token</param>
        /// <returns>Action response</returns>
        public static ActionTokenResponse<T> SuccessfulOperation(T data, string accessToken)
        {
            return new ActionTokenResponse<T>()
            {
                Data = data,
                AccessToken = accessToken,
                StatusCode = 200,
                IsSuccessful = true,
                NotSuccessful = false,
                Errors = new List<string>()
            };
        }
       
    }

    /// <summary>
    /// Manages request responses
    /// </summary>
    public class ActionResponse
    {
        /// <summary>
        /// A constructor
        /// </summary>
        internal ActionResponse()  { }

        /// <summary>
        /// Status Code
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Error Messages
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Verifies if response was successful
        /// </summary>
        public bool IsSuccessful { get; set; } = false;

        /// <summary>
        /// Verifies if response was not successful
        /// </summary>
        public bool NotSuccessful { get; set; } = false;

        /// <summary>
        /// Displays 200 response
        /// </summary>
        /// <returns>Action response</returns>
        public static ActionResponse Successful()
        {
            return new ActionResponse()
            {
                StatusCode = 200,
                IsSuccessful = true,
                NotSuccessful = false,
                Errors = new List<string>()
            };
        }
        /// <summary>
        /// Displays 500 response
        /// </summary>
        /// <param name="error">Error to display</param>
        /// <returns>Action response</returns>
        public static ActionResponse Failed(string error)
        {
            return new ActionResponse()
            {
                StatusCode = 500,
                IsSuccessful = false,
                NotSuccessful = true,
                Errors = new List<string>()
                {
                    error
                }

            };
        }

        /// <summary>
        /// Displays 500 response
        /// </summary>
        /// <returns>Action response</returns>
        public static ActionResponse Failed()
        {
            return new ActionResponse()
            {
                StatusCode = 500,
                IsSuccessful = false,
                NotSuccessful = true,
                Errors = new List<string>()

            };
        }

        /// <summary>
        /// Displays 500 response
        /// </summary>
        /// <param name="error">Error to display</param>
        /// <param name="code">Status code</param>
        /// <returns>Action response</returns>
        public static ActionResponse Failed(string error,int code)
        {
            return new ActionResponse()
            {
                StatusCode = code,
                IsSuccessful = false,
                NotSuccessful = true,
                Errors = new List<string>()
                {
                    error
                }

            };
        }

        /// <summary>
        /// Add error message to response
        /// </summary>
        /// <param name="error">Error to display</param>
        /// <returns>Action response</returns>
        public ActionResponse AddError(string error)
        {
            Errors.Add(error);
            return this;
        }

        /// <summary>
        /// Add error messages to response
        /// </summary>
        /// <param name="errors">Errors to display</param>
        /// <returns>Action response</returns>
        public ActionResponse AddErrors(List<string> errors)
        {
            if (errors == null)
                return this;
            Errors.AddRange(errors);
            return this;
        }

    }

}