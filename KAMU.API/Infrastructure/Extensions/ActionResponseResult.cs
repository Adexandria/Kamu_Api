namespace KAMU.API.Infrastructure.Extensions
{
    public class ActionResponseResult<T> : ActionResponseResult 
    {
        internal ActionResponseResult() { }
        public T Data { get; set; }
        public static ActionResponseResult<T> SuccessfulOperation(T data)
        {
            return new ActionResponseResult<T>()
            {
                Data = data,
                StatusCode = 200,
                IsSuccessful = true,
                NotSuccessful = false,
                Errors = new List<string>()

            };
        }
        public static ActionResponseResult<T> Failed(string error)
        {
            return new ActionResponseResult<T>()
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
        public static ActionResponseResult<T> Failed()
        {
            return new ActionResponseResult<T>()
            {
                StatusCode = 500,
                IsSuccessful = false,
                NotSuccessful = true,
                Errors = new List<string>()

            };
        }
        public static ActionResponseResult<T> Failed(string error, int code)
        {
            return new ActionResponseResult<T>()
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

        public static ActionResponseResult<T> Failed(List<string> error, int statuscode)
        {
            return new ActionResponseResult<T>()
            {
                StatusCode = statuscode,
                IsSuccessful = false,
                NotSuccessful = true,
                Errors = error
            };

        }

        public ActionResponseResult<T> AddError(string error)
        {
            Errors.Add(error);
            return this;
        }

        public ActionResponseResult<T> AddErrors(List<string> errors)
        {
            if (errors == null)
                return this;
            Errors.AddRange(errors);
            return this;
        }
    }

    public class ActionTokenResponseResult<T> : ActionResponseResult<T>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public static ActionTokenResponseResult<T> SuccessfulOperation(T data, string accessToken,string refreshToken)
        {
            return new ActionTokenResponseResult<T>()
            {
                Data = data,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                StatusCode = 200,
                IsSuccessful = true,
                NotSuccessful = false,
                Errors = new List<string>()

            };
        }
       
    }

    
    public class ActionResponseResult
    {
        internal ActionResponseResult()
        {

        }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public bool IsSuccessful { get; set; } = false;
        public bool NotSuccessful { get; set; } = false;

        public static ActionResponseResult Successful()
        {
            return new ActionResponseResult()
            {
                StatusCode = 200,
                IsSuccessful = true,
                NotSuccessful = false,
                Errors = new List<string>()
            };
        }
        public static ActionResponseResult Failed(string error)
        {
            return new ActionResponseResult()
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

        public static ActionResponseResult Failed()
        {
            return new ActionResponseResult()
            {
                StatusCode = 500,
                IsSuccessful = false,
                NotSuccessful = true,
                Errors = new List<string>()

            };
        }
        public static ActionResponseResult Failed(string error,int code)
        {
            return new ActionResponseResult()
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

        public ActionResponseResult AddError(string error)
        {
            Errors.Add(error);
            return this;
        }

        public ActionResponseResult AddErrors(List<string> errors)
        {
            if (errors == null)
                return this;
            Errors.AddRange(errors);
            return this;
        }

    }

}