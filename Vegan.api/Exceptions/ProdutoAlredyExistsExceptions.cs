using System;
using System.Net;

namespace Vegan.api.Exceptions
{
    public class ProdutoAlredyExistsExceptions 
    {
        public class ProdutoAlreadyExistsException : BaseException
        {
            public ProdutoAlreadyExistsException(string message, string uriPath, DateTimeOffset timestamp, Exception? ex = null)
                : base("ProdutoAlreadyExists", message, HttpStatusCode.Conflict, 409, uriPath, timestamp, ex)
            {
            }
        }
    }
}
