using Antlr.Runtime;
using NHibernate;
using System.Net;

namespace KAMU.API.Infrastructure.Utilities
{
    /// <summary>
    /// A model of the response for requests that don't return data
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Adds an error message to the response
        /// </summary>
        /// <param name="message">the error message to add</param>
        public void AddError(string message) 
        {
            Errors.Add(message);
        }
        /// <summary>
        /// sets the properties of a response for a validation failure
        /// </summary>
        /// <param name="response">the response to send on failure</param>
        /// <param name="error">an error message</param>
        public static void ValidationFailure(Response response, string error)
        {
            response.Successful = false;
            response.Code = HttpStatusCode.BadRequest;
            response.AddError(error);
        }

        /// <summary>
        /// Status code for the request response
        /// </summary>
        public HttpStatusCode Code { get; set; }
        private bool successful;
        /// <summary>
        /// indicates a successful request response
        /// </summary>
        public bool Successful
        {
            get { return successful; }
            set 
            {
                if (value == true)
                    Code = HttpStatusCode.OK;
                successful = value; 
            }
        }
        /// <summary>
        /// indicates an unsuccessful request response
        /// </summary>
        public bool NotSuccessful => !Successful;
        /// <summary>
        /// Error messages from an unsuccessful request
        /// </summary>
        public List<string> Errors { get; private set; } = new List<string>();

    }

    /// <summary>
    /// A model of the response for requests that return specified data
    /// </summary>
    /// <typeparam name="T">The type of data to be returned</typeparam>
    public class Response<T> : Response
    {
        /// <summary>
        /// the response data
        /// </summary>
        public T Data { get; set; }
    }
}
