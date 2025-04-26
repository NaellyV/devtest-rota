using System.Net;

namespace RO.DevTest.Domain.Exceptions
{
    public abstract class ApiException : System.Exception
    {
        public abstract HttpStatusCode StatusCode { get; }

        protected ApiException(string message) : base(message) { }
    }
}