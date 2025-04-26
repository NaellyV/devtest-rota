using System.Net;

namespace RO.DevTest.Domain.Exceptions
{
    public class NotFoundException : ApiException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
        
        public NotFoundException(string message) : base(message) { }
        
        public NotFoundException(string entityName, string id) 
            : base($"{entityName} with ID {id} not found") { }
    }
}