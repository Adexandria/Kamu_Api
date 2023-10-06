using Antlr.Runtime;
using NHibernate;
using System.Net;

namespace KAMU.API.Infrastructure.Utilities
{
    public class Response
    {

        public void AddError(string message) 
        {
            Errors.Add(message);
        }

        public static void ValidationFailure(Response response)
        {
            response.Successful = false;
            response.Code = HttpStatusCode.BadRequest;
        }
        public HttpStatusCode Code { get; set; }
        private bool successful;

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

        public bool NotSuccessful => !Successful;
        public List<string> Errors { get; private set; } = new List<string>();

        
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }
    }
}
