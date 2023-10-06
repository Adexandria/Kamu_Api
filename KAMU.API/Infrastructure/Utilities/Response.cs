using System.Net;

namespace KAMU.API.Infrastructure.Utilities
{
    public class Response
    {
        public HttpStatusCode Code { get; set; }
        private bool successful;

        public bool Successful
        {
            get { return successful; }
            set 
            { 
                if(value == true)
                    Code = HttpStatusCode.OK;

                successful = value;
                
            }
        }

        public bool NotSuccessful => !Successful;
        public List<string> Errors { get; set; } = new List<string>();

        
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }
    }
}
